<%@ Page Language="C#" Async="true" MasterPageFile="~/FrontEnd.master" AutoEventWireup="true" CodeBehind="SendMessage.aspx.cs" Inherits="PortCDM.SendMessage" %>

<asp:Content ID="MessageContent" ContentPlaceHolderID="cpMainContent" runat="server">
    <asp:Literal runat="server" ID="vesselImoText">Vessel IMO:</asp:Literal>
    <asp:TextBox ID="vesselImoBox" runat="server"></asp:TextBox>

    <asp:Literal runat="server" ID="commentText">Comment:</asp:Literal>
    <asp:TextBox ID="commentBox" runat="server"></asp:TextBox>

    <asp:DropDownList runat="server" ID="serviceTimeSequenceDropDown">
        <asp:ListItem Text="Commenced" Value="COMMENCED"></asp:ListItem>
        <asp:ListItem Text="Completed" Value="COMPLETED"></asp:ListItem>
        <asp:ListItem Text="Confirmed" Value="CONFIRMED"></asp:ListItem>
        <asp:ListItem Text="Denied" Value="DENIED"></asp:ListItem>
        <asp:ListItem Text="Requested" Value="REQUESTED"></asp:ListItem>
        <asp:ListItem Text="Request Received" Value="REQUEST_RECEIVED"></asp:ListItem>
    </asp:DropDownList>
    <asp:Literal runat="server" ID="testText"></asp:Literal>
    

    <asp:Literal>
        <!--<?xml version="1.0" encoding="UTF-8"?>
<ns2:portCallMessage xmlns:ns2="urn:x-mrn:stm:schema:port-call-message:0.0.16">
   <ns2:portCallId>urn:x-mrn:stm:portcdm:port_call:SEGOT:ca1a795e-ee95-4c96-96d1-53896617c9ac</ns2:portCallId>
   <ns2:vesselId>urn:x-mrn:stm:vessel:IMO:9398917</ns2:vesselId>
   <ns2:messageId>urn:x-mrn:stm:portcdm:message:{uuid()}</ns2:messageId>
   <ns2:reportedAt>2017-03-21T11:59:44.4935008Z</ns2:reportedAt>
  <ns2:serviceState>
    <ns2:serviceObject>ANCHORING</ns2:serviceObject>
    <ns2:time>2017-03-21T11:59:44.4935008Z</ns2:time>
    <ns2:timeSequence>COMMENCED</ns2:timeSequence>
    <ns2:timeType>ESTIMATED</ns2:timeType>
    <ns2:at>
      <ns2:locationType>BERTH</ns2:locationType>
      <ns2:name>UNSPECIFIED_BERTH</ns2:name>
    </ns2:at>
  </ns2:serviceState>
</ns2:portCallMessage>-->
    </asp:Literal>
</asp:Content>