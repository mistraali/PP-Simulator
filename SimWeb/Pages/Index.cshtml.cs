using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator.Maps;
using Simulator;
using System.Text.Json;

namespace SimWeb.Pages
{
    public class IndexModel : PageModel
    {
        public Simulation Simulation { get; }

        public SimulationHistory History { get; }


        public IndexModel()
        {
            Simulation = new Simulation(
                new SmallTorusMap(6, 7),
                [new Orc("Gorbag"), new Elf("Elandor"), new Animals() { Description = "Króliki" },
                    new Birds() { Description = "Or³y", CanFly = true }, new Birds { Description = "Strusie", CanFly = false }],
                [new(2, 2), new(3, 1), new(1, 0), new(3, 5), new(4, 2)],
                "dlrludlddurldul"
            );
            History = new SimulationHistory(Simulation);
        } 

        public void OnGet()
        {
            HttpContext.Session.SetInt32("MaxTurn", History.TurnLogs.Count - 1);
            HttpContext.Session.SetInt32("SizeX", History.SizeX);
            HttpContext.Session.SetInt32("SizeY", History.SizeY);
            for (int i = 0; i < History.TurnLogs.Count; i++)
            {
                HttpContext.Session.SetString($"Turn{i}.Mappable", History.TurnLogs[i].Mappable);
                HttpContext.Session.SetString($"Turn{i}.Move", History.TurnLogs[i].Move);
                HttpContext.Session.SetString($"Turn{i}.Symbols", History.TurnLogs[i].StrigifySymbols());
            }
        }

        public void OnPost()
        {

        }

    }
}
