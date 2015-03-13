using Gnecco.Sigma.Core.InformesInspeccion.Ford.Entidades;
using Gnecco.Sigma.Core.InformesInspeccion.Ford.ObjetosValor;
using Gnecco.Sigma.Core.Shared;
using Gnecco.Sigma.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnecco.Sigma.Web.ViewModels.InformesInspeccion.Ford
{
	public class InformeInspeccionFordViewModel
	{
		public bool EstaEdicion { get; set; }
		public Modelo Model { get; set; }
		public DetalleGrupoArticuloMantenimiento NuevoDetalleGrupoArticuloMantenimiento { get; set; }
		public SubGrupoDesgasteFreno NuevoSubGrupoDesgasteFreno { get; set; }
		public SubGrupoSistemaComponente NuevoSubGrupoSistemaComponente { get; set; }
		public DetalleGrupoDesgasteFreno NuevoDetalleGrupoDesgasteFreno { get; set; }
		public DetalleGrupoDesgasteLlanta NuevoDetalleGrupoDesgasteLlanta { get; set; }
		public DetalleGrupoSistemaComponente NuevoDetalleGrupoSistemaComponente { get; set; }
		
		public class Modelo
		{
			public int Id { get; set; }
			public int InformeInspeccionId { get; set; }
			public string NombreInformeInspeccion { get; set; }
			public string DescripcionInformeInspeccion { get; set; }
			public string CLIENTE { get; set; }
			public string EMAIL { get; set; }
			public string Fecha { get; set; }
			public string OT { get; set; }
			public string MESINSPECCIONESTATAL { get; set; }
			public string Marca { get; set; }
			public string MODELO { get; set; }
			public int? ANIO { get; set; }
			public string MILLAJE { get; set; }
			public string VIN { get; set; }
			public string PLACA { get; set; }
			public string Comentarios { get; set; }
			public string NombreTecnico { get; set; }
			public string AsesorServicio { get; set; }
			public GrupoArticuloMantenimientoViewModel GrupoArticuloMantenimiento { get; set; }
			public GrupoDesgasteFrenoViewModel GrupoDesgasteFreno { get; set; }
			public GrupoDesgasteLlantaViewModel GrupoDesgasteLlanta { get; set; }
			public GrupoSistemaComponenteViewModel GrupoSistemaComponente { get; set; }

			#region Anulados
			public List<int> DetalleGrupoArticuloMantenimientoAnulado { get; set; }
			public List<int> DetalleGrupoDesgasteLlantaAnulado { get; set; }
			public List<int> SubGrupoDesgasteFrenoAnulado { get; set; }
			public List<int> DetalleGrupoDesgasteFrenoAnulado { get; set; }
			public List<int> SubGrupoSistemaComponenteAnulado { get; set; }
			public List<int> DetalleGrupoSistemaComponenteAnulado { get; set; }
			#endregion

			#region BaseViewModel
			public class GrupoViewModel
			{
				public int Id { get; set; }
				public string Descripcion { get; set; }
				public int InformeInspeccionId { get; set; }

				public virtual void MapearDesde(GrupoInformeInspeccion grupoInformeInspeccion)
				{
					Id = grupoInformeInspeccion.Id;
					Descripcion = grupoInformeInspeccion.Descripcion;
					InformeInspeccionId = grupoInformeInspeccion.InformeInspeccionId;
				}
			}

			public class OpcionViewModel
			{
				public int Id { get; set; }
				public int DetalleInformeInspeccionId { get; set; }
				public string Descripcion { get; set; }

				public bool Valor { get; set; }

				public OpcionViewModel()
				{
					
				}

				public virtual void MapearDesde(Opcion opcion)
				{
					Id = opcion.Id;
					DetalleInformeInspeccionId = opcion.DetalleInformeInspeccionId;
					Descripcion = opcion.Descripcion;
				}

				public void EstablecerValor(string valor)
				{
					Valor = valor == "true" ? true : false;
				}
			}

			public class DetalleViewModel
			{
				public int Id { get; set; }
				public string Descripcion { get; set; }

				public virtual void MapearDesde(DetalleInformeInspeccion detalleInformeInspeccion)
				{
					Id = detalleInformeInspeccion.Id;
					Descripcion = detalleInformeInspeccion.Descripcion;
				}
			}
			#endregion

			public class GrupoArticuloMantenimientoViewModel : GrupoViewModel
			{
				public List<DetalleViewModel> Detalle { get; set; }

				public GrupoArticuloMantenimientoViewModel()
				{
					Detalle = new List<DetalleViewModel>();
				}

				public class DetalleViewModel : Modelo.DetalleViewModel
				{
					public int GrupoInformeInspeccionId { get; set; }
					public List<OpcionViewModel> OpcionesReparacion { get; set; }
					public List<OpcionViewModel> OpcionesDesgaste { get; set; }

					public DetalleViewModel()
					{
						OpcionesReparacion = new List<OpcionViewModel>();
						OpcionesDesgaste = new List<OpcionViewModel>();
					}

					public override void MapearDesde(DetalleInformeInspeccion detalleInformeInspeccion)
					{
						base.MapearDesde(detalleInformeInspeccion);

						OpcionesDesgaste.Clear();
						OpcionesReparacion.Clear();

						foreach (var opcion in (detalleInformeInspeccion as DetalleGrupoArticuloMantenimiento).OpcionesDesgaste)
						{
							OpcionViewModel opcionViewModel = new OpcionViewModel();
							opcionViewModel.MapearDesde(opcion);
							OpcionesDesgaste.Add(opcionViewModel);
						}

						foreach (var opcion in (detalleInformeInspeccion as DetalleGrupoArticuloMantenimiento).OpcionesReparacion)
						{
							OpcionViewModel opcionViewModel = new OpcionViewModel();
							opcionViewModel.MapearDesde(opcion);
							OpcionesReparacion.Add(opcionViewModel);
						}
					}
				}

				internal GrupoArticuloMantenimiento CrearEntidad()
				{
					GrupoArticuloMantenimiento grupoArticuloMantenimiento = new GrupoArticuloMantenimiento();

					foreach (var detalle in Detalle)
					{
						grupoArticuloMantenimiento.AgregarModificarDetalle(detalle.Id,detalle.Descripcion);
					}

					return grupoArticuloMantenimiento;
				}

				public void MapearDesde(GrupoArticuloMantenimiento grupoArticuloMantenimiento)
				{
					Detalle.Clear();
					Descripcion = grupoArticuloMantenimiento.Descripcion;
					Id = grupoArticuloMantenimiento.Id;
					foreach (var detalle in grupoArticuloMantenimiento.DetalleActivo)
					{
						DetalleViewModel detalleViewModel = new DetalleViewModel();
						detalleViewModel.MapearDesde(detalle);
						Detalle.Add(detalleViewModel);
					}
				}
			}
			public class GrupoDesgasteLlantaViewModel : GrupoViewModel
			{
				public List<DetalleViewModel> Detalle { get; set; }

				public GrupoDesgasteLlantaViewModel()
				{
					Detalle = new List<DetalleViewModel>();
				}

				public class DetalleViewModel : Modelo.DetalleViewModel
				{
					public int GrupoInformeInspeccionId { get; set; }
					public List<OpcionViewModel> OpcionesReparacion { get; set; }
					public List<OpcionViewModel> OpcionesDesgaste { get; set; }

					public DetalleViewModel()
					{
						OpcionesReparacion = new List<OpcionViewModel>();
						OpcionesDesgaste = new List<OpcionViewModel>();
					}

					public override void MapearDesde(DetalleInformeInspeccion detalleInformeInspeccion)
					{
						base.MapearDesde(detalleInformeInspeccion);

						OpcionesDesgaste.Clear();
						OpcionesReparacion.Clear();

						foreach (var opcion in (detalleInformeInspeccion as DetalleGrupoDesgasteLlanta).OpcionesDesgaste)
						{
							OpcionViewModel opcionViewModel = new OpcionViewModel();
							opcionViewModel.MapearDesde(opcion);
							OpcionesDesgaste.Add(opcionViewModel);
						}

						foreach (var opcion in (detalleInformeInspeccion as DetalleGrupoDesgasteLlanta).OpcionesReparacion)
						{
							OpcionViewModel opcionViewModel = new OpcionViewModel();
							opcionViewModel.MapearDesde(opcion);
							OpcionesReparacion.Add(opcionViewModel);
						}
					}
				}

				public GrupoDesgasteLlanta CrearEntidad()
				{
					GrupoDesgasteLlanta grupoDesgasteLlanta = new GrupoDesgasteLlanta();
					foreach (var detalle in Detalle)
					{
						grupoDesgasteLlanta.AgregarModificarDetalle(detalle.Id,detalle.Descripcion);
					}
					return grupoDesgasteLlanta;
				}

				public void MapearDesde(GrupoDesgasteLlanta grupoDesgasteLlanta)
				{
					Detalle.Clear();

					foreach (var detalle in grupoDesgasteLlanta.DetalleActivo)
					{
						DetalleViewModel detalleViewModel = new DetalleViewModel();
						detalleViewModel.MapearDesde(detalle);
						Detalle.Add(detalleViewModel);
					}
				}
			}
			public class GrupoDesgasteFrenoViewModel : GrupoViewModel
			{
				public List<SubGrupoViewModel> SubGrupos { get; set; }

				public GrupoDesgasteFrenoViewModel()
				{
					SubGrupos = new List<SubGrupoViewModel>();
				}

				public class SubGrupoViewModel : GrupoViewModel
				{
					public int GrupoInformeInspeccionId { get; set; }
					public List<DetalleViewModel> Detalle { get; set; }

					public SubGrupoViewModel()
					{
						Detalle = new List<DetalleViewModel>();
					}

					public override void MapearDesde(GrupoInformeInspeccion grupoInformeInspeccion)
					{
						base.MapearDesde(grupoInformeInspeccion);
						
						Detalle.Clear();

						foreach (var detalle in (grupoInformeInspeccion as SubGrupoDesgasteFreno).DetalleActivo)
						{
							DetalleViewModel detalleViewModel = new DetalleViewModel();
							detalleViewModel.MapearDesde(detalle);
							Detalle.Add(detalleViewModel);
						}
					}

					public SubGrupoDesgasteFreno CrearEntidad(int grupoDesgasteFrenoId, int informeInspeccionId)
					{
						SubGrupoDesgasteFreno subGrupoDesgasteFreno
							= new SubGrupoDesgasteFreno(Descripcion);
						subGrupoDesgasteFreno.GrupoInformeInspeccionId = grupoDesgasteFrenoId;
						subGrupoDesgasteFreno.InformeInspeccionId = informeInspeccionId;

						foreach (var detalle in Detalle)
						{
							subGrupoDesgasteFreno.AgregarModificarDetalle(detalle.Id,detalle.Descripcion);
						}

						return subGrupoDesgasteFreno;
					}
				}

				public class DetalleViewModel : Modelo.DetalleViewModel
				{
					public int GrupoInformeInspeccionId { get; set; }
					public List<OpcionViewModel> OpcionesAtencion { get; set; }
					public List<OpcionViewModel> OpcionesReparacion { get; set; }

					public DetalleViewModel()
					{
						OpcionesAtencion = new List<OpcionViewModel>();
						OpcionesReparacion = new List<OpcionViewModel>();
					}

					public override void MapearDesde(DetalleInformeInspeccion detalleInformeInspeccion)
					{
						base.MapearDesde(detalleInformeInspeccion);

						OpcionesAtencion.Clear();
						OpcionesReparacion.Clear();

						foreach (var opcion in (detalleInformeInspeccion as DetalleGrupoDesgasteFreno).OpcionesAtencion)
						{
							OpcionViewModel opcionViewModel = new OpcionViewModel();
							opcionViewModel.MapearDesde(opcion);
							OpcionesAtencion.Add(opcionViewModel);
						}

						foreach (var opcion in (detalleInformeInspeccion as DetalleGrupoDesgasteFreno).OpcionesReparacion)
						{
							OpcionViewModel opcionViewModel = new OpcionViewModel();
							opcionViewModel.MapearDesde(opcion);
							OpcionesReparacion.Add(opcionViewModel);
						}
					}
				}

				public GrupoDesgasteFreno CrearEntidad(int informeInspeccionId)
				{
					GrupoDesgasteFreno grupoDesgasteFreno = new GrupoDesgasteFreno();
					grupoDesgasteFreno.InformeInspeccionId = informeInspeccionId;
					
					foreach (var subGrupo in SubGrupos)
					{
						grupoDesgasteFreno.AgregarSubGrupo(subGrupo.CrearEntidad(grupoDesgasteFreno.Id, informeInspeccionId));
					}

					return grupoDesgasteFreno;
				}

				public void MapearDesde(GrupoDesgasteFreno grupoDesgasteFreno)
				{
					SubGrupos.Clear();

					foreach (var subGrupo in grupoDesgasteFreno.SubGruposActivo)
					{
						SubGrupoViewModel subGrupoViewModel = new SubGrupoViewModel();
						subGrupoViewModel.MapearDesde(subGrupo);
						SubGrupos.Add(subGrupoViewModel);
					}
				}
			}
			public class GrupoSistemaComponenteViewModel : GrupoViewModel
			{
				public List<SubGrupoViewModel> SubGrupos { get; set; }

				public GrupoSistemaComponenteViewModel()
				{
					SubGrupos = new List<SubGrupoViewModel>();
				}

				public class SubGrupoViewModel : GrupoViewModel
				{
					public int GrupoInformeInspeccionId { get; set; }
					public List<DetalleViewModel> Detalle { get; set; }

					public SubGrupoViewModel()
					{
						Detalle = new List<DetalleViewModel>();
					}

					public override void MapearDesde(GrupoInformeInspeccion grupoInformeInspeccion)
					{
						base.MapearDesde(grupoInformeInspeccion);

						Detalle.Clear();
						foreach (var detalle in (grupoInformeInspeccion as SubGrupoSistemaComponente).DetalleActivo)
						{
							DetalleViewModel detalleViewModel = new DetalleViewModel();
							detalleViewModel.MapearDesde(detalle);
							Detalle.Add(detalleViewModel);
						}
					}

					public SubGrupoSistemaComponente CrearEntidad(int grupoSistemaComponenteId, int informeInspeccionId)
					{
						SubGrupoSistemaComponente subGrupoSistemaComponente
							= new SubGrupoSistemaComponente(Descripcion);
						subGrupoSistemaComponente.GrupoInformeInspeccionId = grupoSistemaComponenteId;
						subGrupoSistemaComponente.InformeInspeccionId = informeInspeccionId;

						foreach (var detalle in Detalle)
						{
							subGrupoSistemaComponente.AgregarModificarDetalle(subGrupoSistemaComponente.Id, detalle.Descripcion);
						}
						return subGrupoSistemaComponente;
					}
				}

				public class DetalleViewModel : Modelo.DetalleViewModel
				{
					public int GrupoInformeInspeccionId { get; set; }
					public List<OpcionViewModel> OpcionesAtencion { get; set; }
					public List<OpcionViewModel> OpcionesReparacion { get; set; }

					public DetalleViewModel()
					{
						OpcionesAtencion = new List<OpcionViewModel>();
						OpcionesReparacion = new List<OpcionViewModel>();
					}

					public override void MapearDesde(DetalleInformeInspeccion detalleInformeInspeccion)
					{
						base.MapearDesde(detalleInformeInspeccion);

						OpcionesReparacion.Clear();
						OpcionesAtencion.Clear();

						foreach (var opcion in (detalleInformeInspeccion as DetalleGrupoSistemaComponente).OpcionesAtencion)
						{
							OpcionViewModel opcionViewModel = new OpcionViewModel();
							opcionViewModel.MapearDesde(opcion);
							OpcionesAtencion.Add(opcionViewModel);
						}

						foreach (var opcion in (detalleInformeInspeccion as DetalleGrupoSistemaComponente).OpcionesReparacion)
						{
							OpcionViewModel opcionViewModel = new OpcionViewModel();
							opcionViewModel.MapearDesde(opcion);
							OpcionesReparacion.Add(opcionViewModel);
						}
					}
				}

				public GrupoSistemaComponente CrearEntidad(int idInformeInspeccion)
				{
					GrupoSistemaComponente grupoDesgasteFreno = new GrupoSistemaComponente();
					grupoDesgasteFreno.InformeInspeccionId = idInformeInspeccion;

					foreach (var subGrupo in SubGrupos)
					{
						grupoDesgasteFreno.AgregarSubGrupo(subGrupo.CrearEntidad(grupoDesgasteFreno.Id, idInformeInspeccion));
					}

					return grupoDesgasteFreno;
				}

				public override void MapearDesde(GrupoInformeInspeccion grupoInformeInspeccion)
				{
					base.MapearDesde(grupoInformeInspeccion);
					SubGrupos.Clear();

					foreach (var subGrupo in (grupoInformeInspeccion as GrupoSistemaComponente).SubGruposActivo)
					{
						SubGrupoViewModel subGrupoViewModel = new SubGrupoViewModel();
						subGrupoViewModel.MapearDesde(subGrupo);
						SubGrupos.Add(subGrupoViewModel);
					}
				}
			}

			public Modelo()
			{
				GrupoArticuloMantenimiento = new GrupoArticuloMantenimientoViewModel();
				GrupoDesgasteFreno = new GrupoDesgasteFrenoViewModel();
				GrupoDesgasteLlanta = new GrupoDesgasteLlantaViewModel();
				GrupoSistemaComponente = new GrupoSistemaComponenteViewModel();
				DetalleGrupoArticuloMantenimientoAnulado = new List<int>();
				DetalleGrupoDesgasteFrenoAnulado = new List<int>();
				DetalleGrupoDesgasteLlantaAnulado = new List<int>();
				SubGrupoDesgasteFrenoAnulado = new List<int>();
				SubGrupoSistemaComponenteAnulado = new List<int>();
				DetalleGrupoSistemaComponenteAnulado = new List<int>();
				Fecha = DateTime.Now.ToShortDateString();
			}

			internal InformeInspeccionFord CrearInformeInspeccionFord()
			{
				InformeInspeccionFord informeInspeccionFord
					= new InformeInspeccionFord(DescripcionInformeInspeccion
												, NombreInformeInspeccion
												, GrupoArticuloMantenimiento.CrearEntidad()
												, GrupoDesgasteFreno.CrearEntidad(0)
												, GrupoDesgasteLlanta.CrearEntidad()
												, GrupoSistemaComponente.CrearEntidad(0));
				informeInspeccionFord.Id = Id;
				return informeInspeccionFord;
			}

			internal void EditarInformeInspeccionFord(InformeInspeccionFord informeInspeccionFord)
			{
				informeInspeccionFord.EditarNombre(NombreInformeInspeccion);
				informeInspeccionFord.EditarDescripcion(DescripcionInformeInspeccion);

				EditarGrupoArticuloMantenimiento(informeInspeccionFord);
				EditarGrupoDesgasteFreno(informeInspeccionFord);
				EditarGrupoSistemaComponente(informeInspeccionFord);
				EditarGrupoDesgasteLlanta(informeInspeccionFord);

				InactivarDetalleGrupoArticuloMantenimiento(informeInspeccionFord);
				InactivarSubGrupoDesgasteFreno(informeInspeccionFord);
				InactivarSubGrupoSistemaComponente(informeInspeccionFord);
				InactivarDetalleGrupoDesgasteLlanta(informeInspeccionFord);
			}

			internal InformeInspeccionFordCompleto CrearInformeInspeccionCompleto()
			{
				InformeInspeccionFordCompleto informeInspeccionFordCompleto =
					new InformeInspeccionFordCompleto
						(
							new ClienteFord(CLIENTE,EMAIL),
							new InformacionVehiculoFord(Marca,MODELO,ANIO.Value,MILLAJE,VIN,PLACA),
							Convert.ToDateTime(Fecha),
							Comentarios,
							AsesorServicio,
							NombreTecnico,
							OT,
							MESINSPECCIONESTATAL
						);
				informeInspeccionFordCompleto.InformeInspeccionId = InformeInspeccionId;

				foreach (var detalle in GrupoArticuloMantenimiento.Detalle)
				{
					List<ValorOpcion> valores = new List<ValorOpcion>();
					
					foreach (var opcion in detalle.OpcionesDesgaste)
					{
						valores.Add(new ValorOpcion(opcion.Id, opcion.Valor ? "true" : "false"));
					}

					foreach (var opcion in detalle.OpcionesReparacion)
					{
						valores.Add(new ValorOpcion(opcion.Id, opcion.Valor ? "true" : "false"));
					}

					informeInspeccionFordCompleto.AgregarDetalle(detalle.Id, valores);
				}

				foreach (var detalle in GrupoDesgasteLlanta.Detalle)
				{
					List<ValorOpcion> valores = new List<ValorOpcion>();
					
					foreach (var opcion in detalle.OpcionesDesgaste)
					{
						valores.Add(new ValorOpcion(opcion.Id, opcion.Valor ? "true" : "false"));
					}

					foreach (var opcion in detalle.OpcionesReparacion)
					{
						valores.Add(new ValorOpcion(opcion.Id, opcion.Valor ? "true" : "false"));
					}

					informeInspeccionFordCompleto.AgregarDetalle(detalle.Id, valores);
				}

				foreach (var subGrupo in GrupoDesgasteFreno.SubGrupos)
				{
					foreach (var detalle in subGrupo.Detalle)
					{
						List<ValorOpcion> valores = new List<ValorOpcion>();
					
						foreach (var opcion in detalle.OpcionesAtencion)
						{
							valores.Add(new ValorOpcion(opcion.Id, opcion.Valor ? "true" : "false"));
						}

						foreach (var opcion in detalle.OpcionesReparacion)
						{
							valores.Add(new ValorOpcion(opcion.Id,opcion.Valor ? "true" : "false"));
						}

						informeInspeccionFordCompleto.AgregarDetalle(detalle.Id, valores);
					}
				}

				foreach (var subGrupo in GrupoSistemaComponente .SubGrupos)
				{
					foreach (var detalle in subGrupo.Detalle)
					{
						List<ValorOpcion> valores = new List<ValorOpcion>();

						foreach (var opcion in detalle.OpcionesAtencion)
						{
							valores.Add(new ValorOpcion(opcion.Id, opcion.Valor ? "true" : "false"));
						}

						foreach (var opcion in detalle.OpcionesReparacion)
						{
							valores.Add(new ValorOpcion(opcion.Id, opcion.Valor ? "true" : "false"));
						}

						informeInspeccionFordCompleto.AgregarDetalle(detalle.Id, valores);
					}
				}

				return informeInspeccionFordCompleto;
			}

			#region Metodos Privados
			private void InactivarDetalleGrupoDesgasteLlanta(InformeInspeccionFord informeInspeccionFord)
			{
				foreach (var detalle in informeInspeccionFord.GrupoDesgasteLlanta.Detalle)
				{
					if (DetalleGrupoDesgasteLlantaAnulado.Contains(detalle.Id))
					{
						detalle.Inactivar();
					}
				}
			}

			private void InactivarSubGrupoSistemaComponente(InformeInspeccionFord informeInspeccionFord)
			{
				foreach (var subGrupo in informeInspeccionFord.GrupoSistemaComponente.SubGrupos)
				{
					if (SubGrupoSistemaComponenteAnulado.Contains(subGrupo.Id))
					{
						subGrupo.Inactivar();
					}
					else
					{
						foreach (var detalle in subGrupo.Detalle)
						{
							if (DetalleGrupoSistemaComponenteAnulado.Contains(detalle.Id))
							{
								detalle.Inactivar();
							}
						}
					}
				}
			}

			private void InactivarSubGrupoDesgasteFreno(InformeInspeccionFord informeInspeccionFord)
			{
				foreach (var subGrupo in informeInspeccionFord.GrupoDesgasteFreno.SubGrupos)
				{
					if (SubGrupoDesgasteFrenoAnulado.Contains(subGrupo.Id))
					{
						subGrupo.Inactivar();
					}
					else
					{
						foreach (var detalle in subGrupo.Detalle)
						{
							if (DetalleGrupoDesgasteFrenoAnulado.Contains(detalle.Id))
							{
								detalle.Inactivar();
							}
						}
					}
				}
			}

			private void InactivarDetalleGrupoArticuloMantenimiento(InformeInspeccionFord informeInspeccionFord)
			{
				foreach (var detalleAnuladoId in DetalleGrupoArticuloMantenimientoAnulado)
				{
					informeInspeccionFord.GrupoArticuloMantenimiento.InactivarDetalle(detalleAnuladoId);
				}
			}

			private void EditarGrupoDesgasteLlanta(InformeInspeccionFord informeInspeccionFord)
			{
				foreach (var detalle in GrupoDesgasteLlanta.Detalle)
				{
					informeInspeccionFord.GrupoDesgasteLlanta.AgregarModificarDetalle(detalle.Id, detalle.Descripcion);
				}
			}

			private void EditarGrupoSistemaComponente(InformeInspeccionFord informeInspeccionFord)
			{
				foreach (var subGrupo in GrupoSistemaComponente.SubGrupos)
				{
					SubGrupoSistemaComponente subGrupoSistemaComponente = informeInspeccionFord.GrupoSistemaComponente.ObtenerSubGrupo(subGrupo.Id);

					if (subGrupoSistemaComponente == null)
					{
						subGrupoSistemaComponente = subGrupo.CrearEntidad(informeInspeccionFord.GrupoDesgasteFreno.Id, informeInspeccionFord.Id);
						informeInspeccionFord.GrupoSistemaComponente.AgregarSubGrupo(subGrupoSistemaComponente);
					}
					else
					{
						subGrupoSistemaComponente.EditarDescripcion(subGrupo.Descripcion);

						foreach (var detalle in subGrupo.Detalle)
						{
							subGrupoSistemaComponente.AgregarModificarDetalle(detalle.Id, detalle.Descripcion);
						}
					}
				}
			}

			private void EditarGrupoArticuloMantenimiento(InformeInspeccionFord informeInspeccionFord)
			{
				foreach (var detalle in GrupoArticuloMantenimiento.Detalle)
				{
					informeInspeccionFord.GrupoArticuloMantenimiento.AgregarModificarDetalle(detalle.Id, detalle.Descripcion);
				}
			}

			private void EditarGrupoDesgasteFreno(InformeInspeccionFord informeInspeccionFord)
			{
				foreach (var subGrupo in GrupoDesgasteFreno.SubGrupos)
				{
					SubGrupoDesgasteFreno subGrupoDesgasteFreno = informeInspeccionFord.GrupoDesgasteFreno.ObtenerSubGrupo(subGrupo.Id);

					if (subGrupoDesgasteFreno == null)
					{
						subGrupoDesgasteFreno = subGrupo.CrearEntidad(informeInspeccionFord.GrupoDesgasteFreno.Id, informeInspeccionFord.Id);
						informeInspeccionFord.GrupoDesgasteFreno.AgregarSubGrupo(subGrupoDesgasteFreno);
					}
					else
					{
						subGrupoDesgasteFreno.EditarDescripcion(subGrupo.Descripcion);

						foreach (var detalle in subGrupo.Detalle)
						{
							subGrupoDesgasteFreno.AgregarModificarDetalle(detalle.Id, detalle.Descripcion);
						}
					}
				}
			}
			#endregion
		}
		
		public InformeInspeccionFordViewModel()
		{
			Model = new Modelo();
			NuevoSubGrupoDesgasteFreno = new SubGrupoDesgasteFreno(null);

			NuevoDetalleGrupoArticuloMantenimiento = new DetalleGrupoArticuloMantenimiento(null);
			NuevoDetalleGrupoArticuloMantenimiento.CrearOpciones();

			NuevoSubGrupoSistemaComponente = new SubGrupoSistemaComponente(null);
			NuevoDetalleGrupoDesgasteFreno = new DetalleGrupoDesgasteFreno(null);
			NuevoDetalleGrupoDesgasteFreno.CrearOpciones();

			NuevoDetalleGrupoDesgasteLlanta = new DetalleGrupoDesgasteLlanta(null);
			NuevoDetalleGrupoDesgasteLlanta.CrearOpciones();

			NuevoDetalleGrupoSistemaComponente = new DetalleGrupoSistemaComponente(null);
			NuevoDetalleGrupoSistemaComponente.CrearOpciones();
		}

		public InformeInspeccionFordViewModel(InformeInspeccionFord informeInspeccionFord)
			:this()
		{
			MapearModelDesde(informeInspeccionFord);
		}

		private void MapearModelDesde(InformeInspeccionFord informeInspeccionFord)
		{
			Model.GrupoArticuloMantenimiento.MapearDesde(informeInspeccionFord.GrupoArticuloMantenimiento);
			Model.GrupoDesgasteFreno.MapearDesde(informeInspeccionFord.GrupoDesgasteFreno);
			Model.GrupoDesgasteLlanta.MapearDesde(informeInspeccionFord.GrupoDesgasteLlanta);
			Model.GrupoSistemaComponente.MapearDesde(informeInspeccionFord.GrupoSistemaComponente);
			Model.NombreInformeInspeccion = informeInspeccionFord.Nombre;
			Model.DescripcionInformeInspeccion = informeInspeccionFord.Descripcion;
			Model.Id = informeInspeccionFord.Id;
		}

		public InformeInspeccionFordViewModel(InformeInspeccionFordCompleto informeInspeccionFordCompleto)
			:this()
		{
			MapearModelDesde(informeInspeccionFordCompleto.InformeInspeccionFord);

			List<ValorOpcion> valoresOpcion = BuscadorObjetos.BuscarTodosLosObjetosDelTipo<ValorOpcion>(informeInspeccionFordCompleto);
			List<Modelo.OpcionViewModel> opcionesViewModel = BuscadorObjetos.BuscarTodosLosObjetosDelTipo<Modelo.OpcionViewModel>(this.Model);

			foreach (var valorOpcion in valoresOpcion)
			{
				Modelo.OpcionViewModel opcionViewModel = opcionesViewModel.FirstOrDefault(ovm => ovm.Id == valorOpcion.OpcionId);
				if(opcionViewModel != null)
					opcionViewModel.Valor = valorOpcion.Valor == "true" ? true : false;
			}

			Model.Comentarios = informeInspeccionFordCompleto.Comentarios;
			Model.AsesorServicio = informeInspeccionFordCompleto.AsesorServicio;
			Model.NombreTecnico = informeInspeccionFordCompleto.Tecnico;
			Model.CLIENTE = informeInspeccionFordCompleto.Cliente.Nombre;
			Model.EMAIL = informeInspeccionFordCompleto.Cliente.CorreoElectronico;
			Model.Fecha = informeInspeccionFordCompleto.Fecha.ToShortDateString();
			Model.Marca = informeInspeccionFordCompleto.InformacionVehiculoFord.Marca;
			Model.MODELO = informeInspeccionFordCompleto.InformacionVehiculoFord.Modelo;
			Model.OT = informeInspeccionFordCompleto.RoTag;
			Model.ANIO = informeInspeccionFordCompleto.InformacionVehiculoFord.Anio;
			Model.MESINSPECCIONESTATAL = informeInspeccionFordCompleto.MesInspeccionEstatal;
			Model.MILLAJE = informeInspeccionFordCompleto.InformacionVehiculoFord.Millaje;
			Model.VIN = informeInspeccionFordCompleto.InformacionVehiculoFord.Vin;
			Model.PLACA = informeInspeccionFordCompleto.InformacionVehiculoFord.Placa;
		}
	}
}