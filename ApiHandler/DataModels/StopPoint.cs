﻿using System.Windows.Media;

namespace VasttrafikAppTest.Models.Geografi.StopPoints;

public class StopPoint
{
    public string gid { get; set; }
    public string stopAreaGid { get; set; }
    public int stopAreaNumber { get; set; }
    public int number { get; set; }
    public string name { get; set; }
    public string shortName { get; set; }
    public string abbreviation { get; set; }
    public string designation { get; set; }
    public int localNumber { get; set; }
    public Municipality municipality { get; set; }
    public List<TariffZone> tariffZones { get; set; }
    public TransportAuthority transportAuthority { get; set; }
    public bool isForBoardning { get; set; }
    public bool isForAlighting { get; set; }
    public bool isRegularTraffic { get; set; }
    public bool isFlexibleBusService { get; set; }
    public bool isFlexibleTaxiService { get; set; }
    public bool isSpecialVehicleTransportConnectionPoint { get; set; }
    public System.Windows.Media.Geometry geometry { get; set; }
    public DateTime validFromDate { get; set; }
    public DateTime validUpToDate { get; set; }
}

