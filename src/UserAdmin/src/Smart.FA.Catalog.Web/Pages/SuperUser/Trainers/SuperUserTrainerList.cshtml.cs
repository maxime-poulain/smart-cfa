﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Options;
using Smart.Design.Razor.TagHelpers.Alert;
using Smart.FA.Catalog.Application.UseCases.Commands;
using Smart.FA.Catalog.Application.UseCases.Queries;
using Smart.FA.Catalog.Core.Domain;
using Smart.FA.Catalog.Core.Services;
using Smart.FA.Catalog.Shared.Collections;
using Smart.FA.Catalog.Web.Options;

namespace Smart.FA.Catalog.Web.Pages.SuperUser.Trainers;

public class List : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string? TrainerNameOrEmailFilterQuery { get; set; }

    [BindProperty(SupportsGet = true)]
    public int CurrentPage { get; set; } = 1;

    private IUserIdentity UserIdentity { get; }

    private IMediator Mediator { get; }

    public SuperUserOptions Settings { get; set; }

    public PagedList<Trainer> TrainerList { get; set; }

    public List(IUserIdentity userIdentity, IMediator mediator, IOptions<SuperUserOptions> superUserOptions)
    {
        UserIdentity = userIdentity;
        Mediator = mediator;
        Settings = superUserOptions.Value;
    }

    public async Task OnGetAsync()
    {
        // Display side panel as selected
        ViewData[nameof(SuperUserSideMenuItem)] = SuperUserSideMenuItem.SuperUserTrainerList;

        // Get All trainers (except the connected trainer) paged
        var getTrainerListRequest = new GetTrainersByCriteriaExceptSelfListRequest
            {
                TrainerNameOrEmailQueryFilter = TrainerNameOrEmailFilterQuery,
                PageItem = new PageItem(CurrentPage, Settings.NumberOfTrainersPerPage),
                SelfTrainerId = UserIdentity.Id
            };
        TrainerList = await Mediator.Send(getTrainerListRequest);
    }

    public async Task<ActionResult> OnPostDeleteAsync(int id)
    {
        // Fetch trainer identity from trainer id
        var trainerResponse = await Mediator.Send(new GetTrainerByIdRequest { TrainerId = id });
        if (!trainerResponse.IsSuccess)
        {
            TempData.AddGlobalAlertMessage(CatalogResources.UnExpectedError, AlertStyle.Error);
            return RedirectToPage();
        }

        // Delete data related to the trainer
        var deleteTrainerWithTrainingsResponse = await Mediator.Send(new DeleteTrainerWithTrainingsRequest { TrainerId = id });
        if (!deleteTrainerWithTrainingsResponse.IsSuccess)
        {
            TempData.AddGlobalAlertMessage(CatalogResources.UnExpectedError, AlertStyle.Error);
            return RedirectToPage();
        }

        // Display success message
        TempData.AddGlobalAlertMessage(CatalogResources.TrainerDeletedWithSuccess, AlertStyle.Success);
        return RedirectToPage();
    }

    public async Task<ActionResult> OnPostBlackListAsync(int id)
    {
        // Fetch trainer identity from trainer id
        var trainerResponse = await Mediator.Send(new GetTrainerByIdRequest { TrainerId = id });
        if (!trainerResponse.IsSuccess)
        {
            TempData.AddGlobalAlertMessage(CatalogResources.UnExpectedError, AlertStyle.Error);
            return RedirectToPage();
        }

        // Blacklist trainer
        var blackListedUserResponse = await Mediator.Send(new BlackListTrainerRequest { TrainerId = trainerResponse.Trainer.Id });
        if (!blackListedUserResponse.IsSuccess)
        {
            TempData.AddGlobalAlertMessage(CatalogResources.UnExpectedError, AlertStyle.Error);
            return RedirectToPage();
        }

        // Display success message
        TempData.AddGlobalAlertMessage(CatalogResources.TrainerBlackListedWithSuccess, AlertStyle.Success);
        return RedirectToPage();
    }

    public async Task<ActionResult> OnPostWhiteListAsync(int id)
    {
        // Fetch trainer identity from trainer id
        var trainerResponse = await Mediator.Send(new GetTrainerByIdRequest { TrainerId = id });
        if (!trainerResponse.IsSuccess)
        {
            TempData.AddGlobalAlertMessage(CatalogResources.UnExpectedError, AlertStyle.Error);
            return RedirectToPage();
        }

        // Whitelist trainer
        var blackListedUserResponse = await Mediator.Send(new WhiteListTrainerRequest { TrainerId = trainerResponse.Trainer.Id });
        if (!blackListedUserResponse.IsSuccess)
        {
            TempData.AddGlobalAlertMessage(CatalogResources.UnExpectedError, AlertStyle.Error);
            return RedirectToPage();
        }

        // Display success message
        TempData.AddGlobalAlertMessage(CatalogResources.TrainerWhiteListedWithSuccess, AlertStyle.Success);
        return RedirectToPage();
    }
}
