using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebApplication13.Models;
using System.Runtime.Intrinsics.Arm;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;

namespace WebApplication13.Controllers
{
    public class ScoreController : Controller
    {
        private readonly BLM19417EContext _context;

        public ScoreController(BLM19417EContext context)
        {
            _context = context;
        }

        // GET: Score
        public async Task<IActionResult> Index()
        {
            var score =_context.Customers 
            .Where(x => x.CosRepresantativeId == x.CosRepresantative.CosRepresantativeId )
            .GroupBy(x => new { x.CosRepresantative.CosRepresantativeId, x.CosRepresantative.FirstName })
            .Select(g => new Score
            
            {
                CosRepresantativeId = g.Key.CosRepresantativeId,
        Name = g.Key.FirstName,
        totalScore = g.Sum(x => x.point)        
    }).ToList(); 
            //.OrderBy(x => x.g.totalScore)
            return View(score);
        }



  
    }



}

