# Decisiones de diseño

Los periodos inician y terminan con el primer día de cada mes. Esto es manejado automaticamente por el sistema tomando en cuenta la fecha actual.

Dado que debe haber un sistema de reporte de ventas por periodos, haremos que hayan datos ya incluidos en la base de datos de fechas pasadas para generar un reporte de muestra. Como administrador, podemos cambiar las fechas de cualquier transacción de venta, este cambio se verá reflejado dinamicamente en el reporte de ventas por periodo.

En el menú de administrador, tendremos un botón para reiniciar la base de datos completamente. Vaciandola por completo y rellenando con datos de relleno.

Los precios de los autos seran en colones. Sin decimales.

Usuario y administrador usaran la misma lógica de clases C#. Diferenciandolos por un boolean para identificarlo como administrador (administradores también son usuarios).

# Dudas 

1) "Visualizar los autos disponibles mediante una vista de carrusel interactiva" ¿Ésto se refiere a una vista en forma de "tarjetas", con una fotografía del vehiculo y su información, que mediante un gesto podemos intercambiar?

R/ ...

2) ¿La base de datos a utilizar puede ser SQLite?

R/ ...

3) Se requiere que los usuarios se registren en el sistema para acceder a la aplicación o son permitidos los usuarios anonimos?

R/ ...

4) "Registrar los datos de clientes que separan/reservan un auto". Con esto se entiende que los usuarios pueden "rentar" un auto.

R/ ...

5) Se mencionan capaz del sistema (base de datos y aplicación que consuma los datos). ¿Con esto se refiere a 2 (o más) diferentes "soluciones" de Visual Studio en el proyecto?

R/ ...

6) ¿Los menús unicamente para uso de administradores deben verse también esteticamente bonitos?

R/ ...