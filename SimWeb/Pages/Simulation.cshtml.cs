﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator;
using Simulator.Maps;
using System.Text.Json;

namespace SimWeb.Pages
{
    public class SimulationModel : PageModel
    {
        public bool IsGeneratable = true;
        public int SizeX { get; set; }
        public int SizeY { get; set; }

        public int MaxTurn { get; set; }
        public int CurrentTurn { get; set; }

        public Dictionary<Point, char> Symbols { get; set; }
        public string Move { get; set; }
        public string Mappable { get; set; }

        public void OnGet()
        {
            int turn;
            if (!int.TryParse(Request.Query["Turn"], out turn))
            {
                turn = 0;
            }
            CurrentTurn = turn;
            
            MaxTurn = HttpContext.Session.GetInt32("MaxTurn") ?? -1;
            string str = HttpContext.Session.GetString($"Turn{turn}.Symbols");
            Mappable = HttpContext.Session.GetString($"Turn{turn}.Mappable");
            Move = HttpContext.Session.GetString($"Turn{turn}.Move");
            SizeX = HttpContext.Session.GetInt32("SizeX") ?? -1;
            SizeY = HttpContext.Session.GetInt32("SizeY") ?? -1;
            if (SizeX == -1 || SizeY == -1 || str == null || Mappable == null || Move == null)
            {
                IsGeneratable = false;
            } else
            {
                Symbols = SimulationTurnLog.DestrigifySymbols(str);
            }
        }
    }

}

