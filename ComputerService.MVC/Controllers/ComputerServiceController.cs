using AutoMapper;
using ComputerService.Application.ComputerService;
using ComputerService.Application.ComputerService.Commands.CreateComputerService;
using ComputerService.Application.ComputerService.Commands.EditComputerService;
using ComputerService.Application.ComputerService.Queries.GetAllComputerServices;
using ComputerService.Application.ComputerService.Queries.GetComputerServiceByEncodedName;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.MVC.Controllers
{
    public class ComputerServiceController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ComputerServiceController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            var carWorkshops = await _mediator.Send(new GetAllComputerServicesQuery());
            return View(carWorkshops);
        }


        [Route("ComputerService/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var dto = await _mediator.Send(new GetComputerServiceByEncodedNameQuery(encodedName));
            return View(dto);
        }


        [Route("ComputerService/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var dto = await _mediator.Send(new GetComputerServiceByEncodedNameQuery(encodedName));

            if (!dto.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }

            EditComputerServiceCommand model = _mapper.Map<EditComputerServiceCommand>(dto);

            return View(model);
        }

        [HttpPost]
        [Route("ComputerService/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName, EditComputerServiceCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);

            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Owner")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> Create(CreateComputerServiceCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);

            }

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
