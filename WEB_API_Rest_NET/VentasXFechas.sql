USE [Restaurante_DOS]
GO
/****** Object:  StoredProcedure [dbo].[spConsultarVtaXFecha]    Script Date: 17/07/2021 13:22:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spConsultarVtaXFecha]
	@fechaInicio date,@FechaFin date
AS
begin
	SELECT t.NroComprobante,  t.Fecha, case when t.Anulado='S' then 'Anulado' when t.Anulado='N' then 'No Anulado' else 'not found' end as 'Estado' ,d.ProductoID , p.Nombre, d.Cantidad, d.Precio
	FROM Transaccion t join DetalleTransaccion d  on t.TransaccionID= d.TransaccionID
	join Producto p on d.ProductoID=p.ProductoID
	where t.TipoOperacionID=2 and (t.Fecha between @fechaInicio and @FechaFin)
end 