using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Web.Mvc;

namespace MyDotLibrary
{
	public class BaseController<TModel,TContext> : Controller where TModel : class, new() 
															  where TContext : class, new()
	{
		private DbContext _db;

		//Uso un delegado para aplicarle dinamicamente el comportamiento
		//que corresponda a la accion siendo ejecutada (Create, Edit, Delete).
		public delegate void ApplyAction(TModel model);
		public ApplyAction ApplyMethod;


		public DbContext DbCtx
		{
			get
			{
				return _db ?? (_db = new TContext() as DbContext);
			}
			set
			{ _db = value; }
		}

		//Obtiene el nombre de la vista en el formato "<Modelo>ViewModel". Ejemplo "CustomerViewModel"
		public string NombreViewModel => typeof(TModel).Name + "ViewModel";


		private ActionResult ApplyActionToModel(TModel model)
		{
			try
			{
				//Delegado aplicado segun la accion origen.
				ApplyMethod(model);
			}
			catch (DbEntityValidationException ex)
			{
				//TODO: Refactorizar catch por estar muy repetido.
				foreach (var item in ex.EntityValidationErrors)
					foreach (var error in item.ValidationErrors)
						ModelState.AddModelError(error.PropertyName, error.ErrorMessage);

				return View(NombreViewModel, model);
			}
			return View(NombreViewModel, model);
		}

		#region CreateMasterModel_Get/Post
		private void CreateBodyMethod(TModel model)
		{
			//Se propaga el estado unchanged, para que
			//las propiedades que sean entidades, no queden tambien marcadas para edicion.
			DbCtx.Entry(model).State = EntityState.Unchanged;

			//Se marca solo el modelo principal como modificado.
			DbCtx.Entry(model).State = EntityState.Added;
			DbCtx.SaveChanges();
		}

		public virtual ActionResult Create() => View(NombreViewModel, new TModel());

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult Create(TModel model)
		{
			ApplyMethod = CreateBodyMethod;
			return ApplyActionToModel(model);
		}
		#endregion


		#region EditMasterModel_Get/Post
		private void EditBodyMethod(TModel model)
		{
			//Mismo caso que en el create. Se propaga el estado unchanged, para que
			//las propiedades que sean entidades, no queden tambien marcadas para edicion.
			DbCtx.Entry(model).State = EntityState.Unchanged;

			//Se marca solo el modelo principal como modificado.
			DbCtx.Entry(model).State = EntityState.Modified;
			DbCtx.SaveChanges();
		}

		public virtual ActionResult Edit(int id)
				=> View(NombreViewModel, DbCtx.Set(typeof(TModel)).Find(id));

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult Edit(TModel model)
		{
			ApplyMethod = EditBodyMethod;
			return ApplyActionToModel(model);
		}
		#endregion

		#region DeleteMasterModel_Get
		public virtual void Delete(int id){
			var model = DbCtx.Set(typeof(TModel)).Find(id);

			if(model != null){
				DbCtx.Entry(model).State = EntityState.Deleted;
				DbCtx.SaveChanges();
			}
		}
		#endregion
	}
}