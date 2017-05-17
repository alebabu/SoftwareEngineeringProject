﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[DataContract(Name = "collection", Namespace = "")]
[Serializable, XmlRoot("collection")]
public class portCallMessages
{
    [XmlElement(ElementName = "portCallMessage", Namespace = "urn:mrn:stm:schema:port-call-message:0.6")]
    public List<portCallMessage> pcms { get; set; }
}

[Serializable]
public class portCallMessage
{
    public string portCallId { get; set; }

    public string localPortCallId { get; set; }

    public string localJobId { get; set; }

    public string vesselId { get; set; }

    public string messageId { get; set; }

    public string groupWith { get; set; }

    public string reportedAt { get; set; }

    public bool reportedAtSpecified { get; set; }

    public string reportedBy { get; set; }

    public string comment { get; set; }

    public LocationState locationState { get; set; }

    public ServiceState serviceState { get; set; }

    public MessageOperation messageOperation { get; set; }

    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces namespaces { get; set; }
}


public class LocationState
{
    public LocationReferenceObject referenceObject { get; set; }

    public DateTime time { get; set; }

    public TimeType timeType { get; set; }

    public LocationStateArrivalLocation arrivalLocation { get; set; }

    public LocationStateDepartureLocation departureLocation { get; set; }
}


public enum LocationReferenceObject
{
    VESSEL,


    TUG,


    ESCORT_TUG,


    PILOT,


    PILOT_BOAT,


    ICEBREAKER,


    AGENT,


    ARRIVAL_MOORER,


    DEPARTURE_MOORER,


    PASSENGER,


    SECURITY,


    PONTOONS_AND_FENDERS,


    BUNKER_VESSEL,


    SLUDGE_VESSEL,


    SLOP_VESSEL,


    FRESH_WATER_VESSEL
}


public enum TimeType
{
    ESTIMATED,


    ACTUAL,


    TARGET,


    RECOMMENDED,


    CANCELLED
}


public class LocationStateArrivalLocation
{
    public Location from { get; set; }

    public Location to { get; set; }
}


public class Location
{
    public LogicalLocation locationType { get; set; }


    public Position position { get; set; }


    public string name { get; set; }
}


public enum LogicalLocation
{
    ANCHORING_AREA,


    BERTH,


    ETUG_ZONE,


    LOC,


    PILOT_BOARDING_AREA,


    RENDEZV_AREA,


    TRAFFIC_AREA,


    TUG_ZONE,


    VESSEL
}


public class Position
{
    public double latitude { get; set; }


    public double longitude { get; set; }
}


public class ServiceState
{
    public ServiceObject serviceObject { get; set; }

    public string performingActor { get; set; }

    public ServiceTimeSequence timeSequence { get; set; }

    public DateTime time { get; set; }

    public TimeType timeType { get; set; }

    public Location at { get; set; }

    public ServiceStateBetween between { get; set; }
}


public enum ServiceObject
{
    ANCHORING,


    ARRIVAL_ANCHORING_OPERATION,


    ARRIVAL_BERTH,


    ARRIVAL_PORTAREA,


    ARRIVAL_VTSAREA,


    BERTH_SHIFTING,


    BUNKERING_OPERATION,


    CARGO_OPERATION,


    DEPARTURE_ANCHORING_OPERATION,


    DEPARTURE_BERTH,


    DEPARTURE_PORTAREA,


    DEPARTURE_VTSAREA,


    ESCORT_TOWAGE,


    GARBAGE_OPERATION,


    ICEBREAKING_OPERATION,


    LUBEOIL_OPERATION,


    ARRIVAL_MOORING_OPERATION,


    DEPARTURE_MOORING_OPERATION,


    PILOTAGE,


    POSTCARGOSURVEY,


    PRECARGOSURVEY,


    PROVISION_OPERATION,


    SLOP_OPERATION,


    SLUDGE_OPERATION,


    TOWAGE,


    WATER_OPERATION,


    GANGWAY,


    EMBARKING,


    PILOT_BOAT,


    PONTOONS_AND_FENDERS,


    SECURITY,


    TOURS,


    FORKLIFT
}


public enum ServiceTimeSequence
{
    COMMENCED,


    COMPLETED,


    CONFIRMED,


    DENIED,


    REQUESTED,


    REQUEST_RECEIVED
}


public class ServiceStateBetween
{
    public Location to { get; set; }


    public Location from { get; set; }
}


public class MessageOperation
{
    public MessageOperationOperation operation { get; set; }


    public string messageId { get; set; }
}


public enum MessageOperationOperation
{
    WITHDRAW
}


public class LocationStateDepartureLocation
{
    public Location from { get; set; }


    public Location to { get; set; }
}