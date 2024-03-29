using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    [Route("[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet(nameof(Index))]
        public async Task<IActionResult> Index()
        {
            var categories = await _service.GetCategories();
            return View(categories);
        }

        [HttpGet(nameof(Create))]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id) 
        {
            if (id == null) return NotFound();

            var categoryDto = await _service.GetById(id);

            if(categoryDto == null) return NotFound();

            return View(categoryDto);
        }

        [HttpPost] 
        public async Task<IActionResult> Edit(CategoryDTO category) 
        { 
            if(ModelState.IsValid)
            {
                try { 
                    await _service.Update(category);
                }catch (Exception) {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        [HttpPost(nameof(Create))]
        public async Task<IActionResult> Create(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                await _service.Add(category);
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }
    }

}

