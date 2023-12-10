using System.Collections.ObjectModel;
using VasttrafikWindows.Api.DataModels.Responses;

namespace VasttrafikWindows.Models;

public class MainModel
{
    public string _geografiStopPointOutputString;
    public string _geografiStopPointEndPointString;

    public string _planeraResaDepartuesEndPointString;
    public string _planeraResaOutputString;

    public ObservableCollection<GeografiStopAreaResponse> _geografiStopAreaResponseCollection;

}