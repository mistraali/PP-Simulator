using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator;
using Simulator.Maps;
using System.Text.Json;

namespace SimWeb.Pages
{
    public class SimulationModel : PageModel
    {
        public Simulation Simulation { get; }

        public SimulationHistory History { get; }

        public int MaxTurn { get; }
        public int CurrentTurn { get; set; }

        public SimulationModel()
        {
            Simulation = new Simulation(
                new SmallTorusMap(6, 7),
                [new Orc("Gorbag"), new Elf("Elandor"), new Animals() { Description = "Króliki" }, 
                    new Birds() { Description = "Orły", CanFly = true }, new Birds { Description = "Strusie", CanFly = false }],
                [new(2, 2), new(3, 1), new(1, 0), new(3, 5), new(4, 2)],
                "dlrludlddurldul"
            );
            History = new SimulationHistory(Simulation);

            MaxTurn = History.TurnLogs.Count - 1;
            CurrentTurn = 0;
        }

        public void OnGet()
        {
            int turn;
            if (!int.TryParse(Request.Query["turn"], out turn))
            {
                turn = 0;
            }
            CurrentTurn = turn;
        }
    }

}

