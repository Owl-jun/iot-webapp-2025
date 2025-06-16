﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyPortfolioWebApp.Models;

namespace MyPortfolioWebApp.Controllers
{
    public class BoardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BoardController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Board
        public async Task<IActionResult> Index()
        {
<<<<<<< HEAD:day10/Day10Study/MyPortfolioWebApp/Controllers/BoardController.cs
            
            return View(await _context.Board.ToListAsync());
=======
            var totalCount = _context.Board
                .Where(b => EF.Functions.Like(b.Title, $"%{search}%"))
                .Count();

            var countList = 10;
            var totalPage = (int)Math.Ceiling(totalCount / (double)countList);

            // 예외 처리: 게시글이 없을 경우
            if (totalPage == 0) totalPage = 1;

            if (page > totalPage) page = totalPage;
            if (page < 1) page = 1;

            var countPage = 10;
            var startPage = ((page - 1) / countPage) * countPage + 1;
            var endPage = startPage + countPage - 1;
            if (totalPage < endPage) endPage = totalPage;

            var skip = (page - 1) * countList;

            ViewBag.StartPage = startPage;
            ViewBag.EndPage = endPage;
            ViewBag.Page = page;
            ViewBag.TotalPage = totalPage;
            ViewBag.Search = search;

            var boardList = await _context.Board
                .Where(b => EF.Functions.Like(b.Title, $"%{search}%"))
                .OrderByDescending(b => b.PostDate)
                .Skip(skip)
                .Take(countList)
                .ToListAsync();

            return View(boardList);
>>>>>>> parent of bb0c90c (13):Day10Study/MyPortfolioWebApp/Controllers/BoardController.cs
        }


        // GET: Board/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var board = await _context.Board
                .FirstOrDefaultAsync(m => m.Id == id);
            if (board == null)
            {
                return NotFound();
            }
<<<<<<< HEAD:day10/Day10Study/MyPortfolioWebApp/Controllers/BoardController.cs
=======

            board.ReadCount++;
            _context.Board.Update(board);
            await _context.SaveChangesAsync();
>>>>>>> parent of bb0c90c (13):Day10Study/MyPortfolioWebApp/Controllers/BoardController.cs

            return View(board);
        }

        // GET: Board/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Board/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
<<<<<<< HEAD:day10/Day10Study/MyPortfolioWebApp/Controllers/BoardController.cs
        [ValidateAntiForgeryToken]
=======
        //[ValidateAntiForgeryToken]
>>>>>>> parent of bb0c90c (13):Day10Study/MyPortfolioWebApp/Controllers/BoardController.cs
        public async Task<IActionResult> Create([Bind("Id,Email,Writer,Title,Contents,PostDate,ReadCount")] Board board)
        {
            if (ModelState.IsValid)
            {
                _context.Add(board);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(board);
        }

        // GET: Board/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var board = await _context.Board.FindAsync(id);
            if (board == null)
            {
                return NotFound();
            }
            return View(board);
        }

        // POST: Board/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
<<<<<<< HEAD:day10/Day10Study/MyPortfolioWebApp/Controllers/BoardController.cs
        [ValidateAntiForgeryToken]
=======
        //[ValidateAntiForgeryToken]
>>>>>>> parent of bb0c90c (13):Day10Study/MyPortfolioWebApp/Controllers/BoardController.cs
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Writer,Title,Contents,PostDate,ReadCount")] Board board)
        {
            if (id != board.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(board);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoardExists(board.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(board);
        }

        // GET: Board/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var board = await _context.Board
                .FirstOrDefaultAsync(m => m.Id == id);
            if (board == null)
            {
                return NotFound();
            }

            return View(board);
        }

        // POST: Board/Delete/5
        [HttpPost, ActionName("Delete")]
<<<<<<< HEAD:day10/Day10Study/MyPortfolioWebApp/Controllers/BoardController.cs
        [ValidateAntiForgeryToken]
=======
        //[ValidateAntiForgeryToken]
>>>>>>> parent of bb0c90c (13):Day10Study/MyPortfolioWebApp/Controllers/BoardController.cs
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var board = await _context.Board.FindAsync(id);
            if (board != null)
            {
                _context.Board.Remove(board);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoardExists(int id)
        {
            return _context.Board.Any(e => e.Id == id);
        }
    }
}
