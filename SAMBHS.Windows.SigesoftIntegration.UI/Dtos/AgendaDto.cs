using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAMBHS.Windows.SigesoftIntegration.UI.Dtos
{
    public class AgendaDto
    {
        public int? i_LineStatusId { get; set; }
        public int? i_CalendarStatusId { get; set; }
        public int? i_StatusLiquidation { get; set; }
        public int? i_IsVipId { get; set; }
        public int i_ServiceTypeId { get; set; }
        public int i_NewContinuationId { get; set; }
        public int i_ServiceStatusId { get; set; }
        public string v_EmployerOrganizationId { get; set; }
        public string v_ServiceId { get; set; }
        public string v_CalendarId { get; set; }
        public DateTime? d_DateTimeCalendar { get; set; }
        public string v_Pacient { get; set; }
        public string v_DocNumber { get; set; }
        public string v_LineStatusName { get; set; }
        public string v_ServiceStatusName { get; set; }
        public DateTime? d_SalidaCM { get; set; }
        public string v_AptitudeStatusName { get; set; }
        public string v_ServiceTypeName { get; set; }
        public string v_ServiceName { get; set; }
        public string v_NewContinuationName { get; set; }
        public string v_EsoTypeName { get; set; }
        public string v_CalendarStatusName { get; set; }
        public string v_ProtocolName { get; set; }
        public string v_IsVipName { get; set; }
        public string v_OrganizationLocationProtocol { get; set; }
        public string v_OrganizationLocationService { get; set; }
        public DateTime? d_EntryTimeCM { get; set; }
        public DateTime? d_CircuitStartDate { get; set; }
        public bool b_Seleccionar { get; set; }
        public int i_Edad { get; set; }
        public string GESO { get; set; }
        public string Puesto { get; set; }
        public string Nombres { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }
        public byte[] HuellaTrabajador { get; set; }
        public byte[] FirmaTrabajador { get; set; }
        public string v_WorkingOrganizationName{ get; set; }
        public string v_ProtocolId { get; set; }
        public byte[] FotoTrabajador { get; set; }
        public DateTime? d_Birthdate { get; set; }
        public float? PrecioTotalProtocolo { get; set; }
        public string v_PersonId { get; set; }
        public string v_NumberDocument { get; set; }
        public int i_MasterServiceId { get; set; }
        public int i_MedicoTratanteId { get; set; }
        public string v_OrganizationId { get; set; }
        public string RucEmpFact { get; set; }
        public string v_CreationUser { get; set; }
        public string v_ComprobantePago { get; set; }
        public string v_NroLiquidacion { get; set; }
        public string MEDICO { get; set; }
        public string CONSULTORIO { get; set; }
        public string VENDEDOR { get; set; }
        public string IMPORTE { get; set; }
        public string HISTORIA { get; set; }
        public string COMPROBANTE { get; set; }
        public string PROTOCOLO { get; set; }

        public List<AgendaDtoNew1> AgendaDtoNewList1 { get; set; }
    }

    public class AgendaDtoNew1
    {
        public string v_Pacient { get; set; }
        public string v_DocNumber { get; set; }
        public string MEDICO { get; set; }
        public string CONSULTORIO { get; set; }
        public string VENDEDOR { get; set; }
        public string IMPORTE { get; set; }
        public string HISTORIA { get; set; }
        public string COMPROBANTE { get; set; }

        public List<AgendaDtoNew2> AgendaDtoNewList2 { get; set; }

    }

    public class AgendaDtoNew2
    {
        public string v_Pacient { get; set; }
        public int i_Edad { get; set; }
        public string v_DocNumber { get; set; }
        public string MEDICO { get; set; }
        public string CONSULTORIO { get; set; }
        public string VENDEDOR { get; set; }
        public string IMPORTE { get; set; }
        public string HISTORIA { get; set; }
        public string COMPROBANTE { get; set; }
        public DateTime? d_DateTimeCalendar { get; set; }
        public string PROTOCOLO { get; set; }
    }
}
