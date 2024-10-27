Instrucciones para Clonar el Repositorio
Para que el proyecto funcione en sus entornos locales, deben seguir estos pasos:

1.Restaurar las Dependencias del Proyecto
Abre la Consola del Administrador de Paquetes de NuGet desde 

Herramientas > Administrador de paquetes de NuGet > Consola del Administrador de paquetes 

y ejecuta el siguiente comando:

dotnet restore


2.Actualizar la Base de Datos
Asegúrate de que todas las migraciones estén aplicadas ejecutando el siguiente comando:

Update-Database