using System.Collections.Generic;
using System.Linq;
using AtosLibrary.Presentation.Chart;
using AtosLibrary.Presentation.Reservation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace AtosLibrary.WebHost.Pages
{
    public class IndexModel : PageModel
    {
        class Statistic
        {
            public string key { get; set; }
            public int cnt { get; set; }
        }

        private readonly IReservationPresentationRepository _reservationPresentationRepository;

        public string BookChartJson { get; set; }
        public string ReaderChartJson { get; set; }

        public IndexModel(IReservationPresentationRepository reservationPresentationRepository)
        {
            _reservationPresentationRepository = reservationPresentationRepository;
        }

        public void OnGet()
        {
            PrepareTopBooksChart();
            PrepareTopReadersChart();
        }

        private void PrepareTopBooksChart()
        {
            var topBooks = _reservationPresentationRepository.Search("")
                .OrderBy(x => x.BookName)
                .GroupBy(x => x.BookName)
                .Select(grp => new Statistic() {key = grp.Key, cnt = grp.Count()})
                .OrderBy(x => x.cnt)
                .Take(5)
                .ToList();

            BookChartJson = PrepareChart(topBooks);
        }

        private void PrepareTopReadersChart()
        {
            var topReaders = _reservationPresentationRepository.Search("")
                .OrderBy(x => x.ReaderName)
                .GroupBy(x => x.ReaderName)
                .Select(grp => new Statistic() {key = grp.Key, cnt = grp.Count()})
                .OrderBy(x => x.cnt)
                .Take(5)
                .ToList();

            ReaderChartJson = PrepareChart(topReaders);
        }

        private string PrepareChart(List<Statistic> topList)
        {
            var names = System.Text.Json.JsonSerializer.Serialize(topList.Select(x => x.key).ToList());
            var count = System.Text.Json.JsonSerializer.Serialize(topList.Select(x => x.cnt).ToList());

            // Ref: https://www.chartjs.org/docs/latest/  
            var chartData = @"{
            type: 'bar',
            responsive: true,
            data:
            {
                labels: " + names + @",
                datasets: [{
                    label: '# of rentals',
                    data: " + count + @",
                    backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(255, 206, 86, 0.2)',
                    'rgba(75, 192, 192, 0.2)',
                    'rgba(153, 102, 255, 0.2)'
                        ],
                    borderColor: [
                    'rgba(255, 99, 132, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 206, 86, 1)',
                    'rgba(75, 192, 192, 1)',
                    'rgba(153, 102, 255, 1)'
                        ],
                    borderWidth: 1
                }]
            },
            options:
            {
                scales:
                {
                    yAxes: [{
                        ticks:
                        {
                            beginAtZero: true
                        }
                    }]
                }
            }
        }";

            ChartJs chart = JsonConvert.DeserializeObject<ChartJs>(chartData);
            return JsonConvert.SerializeObject(chart, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            });
        }
    }
}