//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/09/28 - 14:12:25
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using SAMBHS.Common.DataModel;

namespace SAMBHS.Common.BE
{

    /// <summary>
    /// Assembler for <see cref="vendedor"/> and <see cref="vendedorDto"/>.
    /// </summary>
    public static partial class vendedorAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="vendedorDto"/> converted from <see cref="vendedor"/>.</param>
        static partial void OnDTO(this vendedor entity, vendedorDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="vendedor"/> converted from <see cref="vendedorDto"/>.</param>
        static partial void OnEntity(this vendedorDto dto, vendedor entity);

        /// <summary>
        /// Converts this instance of <see cref="vendedorDto"/> to an instance of <see cref="vendedor"/>.
        /// </summary>
        /// <param name="dto"><see cref="vendedorDto"/> to convert.</param>
        public static vendedor ToEntity(this vendedorDto dto)
        {
            if (dto == null) return null;

            var entity = new vendedor();

            entity.v_IdVendedor = dto.v_IdVendedor;
            entity.i_SystemUser = dto.i_SystemUser;
            entity.v_CodVendedor = dto.v_CodVendedor;
            entity.v_NombreCompleto = dto.v_NombreCompleto;
            entity.v_Contacto = dto.v_Contacto;
            entity.v_Direccion = dto.v_Direccion;
            entity.i_IdTipoPersona = dto.i_IdTipoPersona;
            entity.i_IdTipoIdentificacion = dto.i_IdTipoIdentificacion;
            entity.v_NroDocIdentificacion = dto.v_NroDocIdentificacion;
            entity.v_Telefono = dto.v_Telefono;
            entity.v_Fax = dto.v_Fax;
            entity.v_Correo = dto.v_Correo;
            entity.i_IdPais = dto.i_IdPais;
            entity.i_IdDepartamento = dto.i_IdDepartamento;
            entity.i_IdProvincia = dto.i_IdProvincia;
            entity.i_IdDistrito = dto.i_IdDistrito;
            entity.i_Eliminado = dto.i_Eliminado;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;
            entity.i_PermiteAnularVentas = dto.i_PermiteAnularVentas;
            entity.i_PermiteEliminarVentas = dto.i_PermiteEliminarVentas;
            entity.i_IdAlmacen = dto.i_IdAlmacen;
            entity.i_EsActivo = dto.i_EsActivo;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="vendedor"/> to an instance of <see cref="vendedorDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="vendedor"/> to convert.</param>
        public static vendedorDto ToDTO(this vendedor entity)
        {
            if (entity == null) return null;

            var dto = new vendedorDto();

            dto.v_IdVendedor = entity.v_IdVendedor;
            dto.i_SystemUser = entity.i_SystemUser;
            dto.v_CodVendedor = entity.v_CodVendedor;
            dto.v_NombreCompleto = entity.v_NombreCompleto;
            dto.v_Contacto = entity.v_Contacto;
            dto.v_Direccion = entity.v_Direccion;
            dto.i_IdTipoPersona = entity.i_IdTipoPersona;
            dto.i_IdTipoIdentificacion = entity.i_IdTipoIdentificacion;
            dto.v_NroDocIdentificacion = entity.v_NroDocIdentificacion;
            dto.v_Telefono = entity.v_Telefono;
            dto.v_Fax = entity.v_Fax;
            dto.v_Correo = entity.v_Correo;
            dto.i_IdPais = entity.i_IdPais;
            dto.i_IdDepartamento = entity.i_IdDepartamento;
            dto.i_IdProvincia = entity.i_IdProvincia;
            dto.i_IdDistrito = entity.i_IdDistrito;
            dto.i_Eliminado = entity.i_Eliminado;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;
            dto.i_PermiteAnularVentas = entity.i_PermiteAnularVentas;
            dto.i_PermiteEliminarVentas = entity.i_PermiteEliminarVentas;
            dto.i_IdAlmacen = entity.i_IdAlmacen;
            dto.i_EsActivo = entity.i_EsActivo;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="vendedorDto"/> to an instance of <see cref="vendedor"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<vendedor> ToEntities(this IEnumerable<vendedorDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="vendedor"/> to an instance of <see cref="vendedorDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<vendedorDto> ToDTOs(this IEnumerable<vendedor> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
