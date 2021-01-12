﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FRM007A.aspx.cs" Inherits="SAMBHS.Server.WebClientAdmin.UI.Common.FRM007A" %>
<%@ Register assembly="FineUI" namespace="FineUI" tagprefix="x" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" AutoSizePanelID="Panel5" runat="server"  />
        <x:Panel ID="Panel5" runat="server" ShowBorder="True" BodyPadding="5px" ShowHeader="False" EnableBackgroundColor="True">
            <Toolbars>
                <x:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <x:Button ID="btnSaveRefresh" Text="Guardar y Cerrar" runat="server" Icon="SystemSave" OnClick="btnSaveRefresh_Click" ValidateForms="Form2,SimpleForm2" 
                            TabIndex="8">
                        </x:Button>
                        <x:Button ID="btnClose" EnablePostBack="false" Text="Cancelar y Cerrar" runat="server" Icon="SystemClose" TabIndex="9">
                        </x:Button>
                    </Items>
                </x:Toolbar>
            </Toolbars>
            <Items>
                <x:Panel ID="Panel6" AutoHeight="true" EnableBackgroundColor="True"
                    runat="server" BodyPadding="2px" ShowBorder="False" ShowHeader="False">
                    <Items>
                        <x:GroupPanel runat="server" Title="Datos Generales" ID="GroupPanel4" Width ="420">
                            <Items>
                                <x:Form ID="Form2" runat="server" EnableBackgroundColor="true" ShowBorder="False" ShowHeader="False"
                                    LabelWidth="60px">
                                    <Rows>
                                        <x:FormRow ID="FormRow1" runat="server">
                                            <Items>
                                                <x:TextBox ID="txtName" Label="Nombre" Required="true" ShowRedStar="true" runat="server" TabIndex="1" MaxLength="100"  CssClass="mrightmayus"
                                                    MaxLengthMessage="El número máximo de caracteres permitidos es 100" Width = "300px" />                                              
                                            </Items>
                                        </x:FormRow>                                       
                                    </Rows>
                                </x:Form>
                            </Items>
                        </x:GroupPanel>
                    
                    </Items>
                </x:Panel>
            </Items>
        </x:Panel>
      
    </form>
</body>
</html>
