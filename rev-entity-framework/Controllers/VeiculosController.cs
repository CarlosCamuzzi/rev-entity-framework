using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rev_entity_framework.Models;

namespace rev_entity_framework.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly AppDbContext _context;
        // Injeção de dependência
        // O construtor veiculos acessa o contexto de dados para manipular o banco de dados
        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]   // Exibir a tela inicial
        public async Task<IActionResult> Index()
        {
            var dados = await _context.Veiculos.ToListAsync();

            return View(dados);
        }

        [HttpGet]   // Exibir a tela de cadastar o veículo
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]  // Cadastrar o veículo
        public async Task<IActionResult> Create(Veiculo veiculo)
        {
            if (ModelState.IsValid)     // Verifica se o modelo de dados é válido
            {
                _context.Veiculos.Add(veiculo);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(veiculo);
        }

        [HttpGet]   // Buscando o dado que será atualizado
        public async Task<IActionResult> Edit(int? id)  // View criada a partir daqui
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Veiculos.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost]  // Editar os dados do veículo
        public async Task<IActionResult> Edit(int id, Veiculo veiculo)
        {
            if(id != veiculo.Id)            
                return NotFound();

            if (ModelState.IsValid)     // Verifica se o modelo de dados é válido
            {
                _context.Veiculos.Update(veiculo);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(veiculo);
        }

        [HttpGet]   // Visualizar dados do veículo
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Veiculos.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpGet]    // Buscando o dado que será apagado
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Veiculos.FindAsync(id);

            if (dados == null)
                return NotFound();            

            return View(dados);
        }

        [HttpPost, ActionName("Delete")]    // Cofirmar a remoção do veículo
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Veiculos.FindAsync(id);

            if (dados == null)
                return NotFound();

            _context.Veiculos.Remove(dados);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
