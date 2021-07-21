using System;
using Xunit;
using Moq;
using GenFu;
using Permissions.Challenge.Data.Model;
using Permissions.Challenge.Data.DAL;
using Permissions.Challenge.Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Permissions.Challenge.Api.Test
{
    public class PermissionsTest
    {

        private IEnumerable<Permiso> GetTestData()
        {
            A.Configure<Permiso>()
                .Fill(x => x.NombreEmpleado).AsFirstName()
                .Fill(x => x.Id, () => { return new int(); });

            var dataList = A.ListOf<Permiso>(10);

            TipoPermiso permissionType = new TipoPermiso();
            permissionType.Descripcion = "Licencia";
            dataList[0].TipoPermiso = permissionType;

            return dataList;
        }

        private Mock<IUnitOfWork> CreateIUnitOfWork()
        {
            //Configuración de instancia local de Entity Framework

            var dataTest = GetTestData().AsQueryable();

            var dbSet = new Mock<DbSet<Permiso>>();
            dbSet.As<IQueryable<Permiso>>().Setup(x => x.Provider).Returns(dataTest.Provider);
            dbSet.As<IQueryable<Permiso>>().Setup(x => x.Expression).Returns(dataTest.Expression);
            dbSet.As<IQueryable<Permiso>>().Setup(x => x.ElementType).Returns(dataTest.ElementType);
            dbSet.As<IQueryable<Permiso>>().Setup(x => x.GetEnumerator()).Returns(dataTest.GetEnumerator());

            dbSet.As<IAsyncEnumerable<Permiso>>().Setup(x => x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
                .Returns(new AsyncEnumerator<Permiso>(dataTest.GetEnumerator()));

            var UoW = new Mock<IUnitOfWork>();
            UoW.Setup(x => x.Query<Permiso>()).Returns(dbSet.Object);

            return UoW;

        }

        [Fact]
        public void GetAllPermissions()
        {
            System.Diagnostics.Debugger.Launch();
            //Identificar el método que realiza la consulta a la base de datos
            // 1 - Emular a la instancia de Entity Framwork Core
            // Para emular las acciones y eventos de un objeto en un ambiente de Test, se utilizan objetos de tipo mock
            // 2 - Emular Mapping, si corresponde
            // 3 - Instanciar la clase PermisoDomain y pasarle los mocks que he creado

            var mockUoW = CreateIUnitOfWork();

            PermisoDomain permisoDomain = new PermisoDomain(mockUoW.Object);

            var permissionDataAll = permisoDomain.GetAll().ToList();

            Assert.True(permissionDataAll.Any());

        }
    }
}
