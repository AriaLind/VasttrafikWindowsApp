﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using VasttrafikAppTest.VasttrafikAPI;
using VasttrafikWindows.Api.DataModels;
using VasttrafikWindows.Api.DataModels.Responses;
using VasttrafikWindows.Api.Deserializers;
using VasttrafikWindows.Models;

namespace VasttrafikWindows.ViewModels;

public class PrimaryViewModel : ObservableObject
{
    private readonly PrimaryModel _primaryModel;

    public PrimaryViewModel(PrimaryModel primaryModel)
    {
        _primaryModel = primaryModel;
        _primaryModel.InitializeStopAreaCollection();
        RefreshFilteredStopAreas();
    }

    public string SearchBoxText
    {
        get => _primaryModel._searchBoxText;
        set
        {
            SetProperty(ref _primaryModel._searchBoxText, value);
            FilteredStopAreas = _primaryModel.FilterStops();
        } 
    }

    private ObservableCollection<StopArea> _filteredStopAreas;

    public ObservableCollection<StopArea> FilteredStopAreas
    {
        get => _filteredStopAreas;
        set
        {
            SetProperty(ref _filteredStopAreas, value);
        } 
    }

    //public ObservableCollection<StopArea> StopAreaCollection
    //{
    //    get => _primaryModel.GeografiStopAreaCollection;
    //    set => SetProperty(ref _primaryModel.GeografiStopAreaCollection, value);
    //}

    public StopArea SelectedStopArea
    {
        get => _primaryModel._selectedStopArea;
        set
        {
            SetProperty(ref _primaryModel._selectedStopArea, value);
            ShowDepartures();
        } 
    }

    public ObservableCollection<Result> SelectedStopAreaDepartures
    {
        get => _primaryModel._selectedStopAreaDepartures;
        set => SetProperty(ref _primaryModel._selectedStopAreaDepartures, value);
    }

    public async void RefreshFilteredStopAreas()
    {
        FilteredStopAreas = new ObservableCollection<StopArea>(await _primaryModel.RefreshFilteredStopAreaList());
    }

    public async void ShowDepartures()
    {
        var jsonResponse = await PlaneraResaGetRequest.GetStopAreaDepartures(SelectedStopArea.gid);
        var departuresResponse = PlaneraResaDeserialization.DeparturesDeserializer(jsonResponse);
        if (departuresResponse == null)
        {
            return;
        }

        foreach (var departure in departuresResponse.results)
        {
            if (DateTime.TryParse(departure.estimatedOtherwisePlannedTime, out var estTime))
            {
                departure.formattedDepartureTime = estTime.ToString("HH:mm");
                var estimatedTimeTimeSpan = estTime - DateTime.Now;
                if (estimatedTimeTimeSpan.TotalSeconds > 0)
                {
                    departure.formattedMinutesSecondsUntilDeparture = estimatedTimeTimeSpan.ToString("mm':'ss");
                }
                else
                {
                    departure.formattedMinutesSecondsUntilDeparture = "Departed";
                }
            }
            else
            {
                MessageBox.Show("Error parsing datetime.");
            }
        }
        SelectedStopAreaDepartures = new ObservableCollection<Result>();
        foreach (var departure in departuresResponse.results)
        {
            SelectedStopAreaDepartures.Add(departure);
        }
    }

    //public IRelayCommand GeografiStopPointsOutputCommand { get; set; }
    //public IRelayCommand PlaneraResaStopPointsOutputCommand { get; set; }
}