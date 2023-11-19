# Voyages

RESUME:

React web site that uses BootStrap and an Apollo client to get data from a GraphQL server (asp.net core), that consults a API REST (asp.net core). It includes Test Proyects for GraphQL server and API REST.

DESCRIPTION:

Este proyecto es una aplicación web de una agencia de viajes que muestra información de los viajes de los clientes. Es una demo para mostrar el funcionamiento de una arquitectura compleja, compuesta por una web, un servidor GraphQL y varios servicios API REST.

ARCHITECTURE:

La arquitectura consta de 3 partes principales:

-1º Servicio API REST (Servidor):

Conjunto de varios servicios API REST que devuelven información sobre un cliente, el dossier de un viaje o un producto.
Esta aplicación está desarrollada con .Net Core y escrita en C#.
La ruta donde se encuentra el proyecto que implementa el servicio API REST es "/Server/Voyages.WebApi". 
La arquitectura interna se basa en el principio de inversión de dependencias. Hace uso del proyecto "/Server/Voyages.Domain", que implementa la capa de dominio e incluye las diferentes Entidades y las interfaces de los servicios y los repositorios, y tambien del proyecto "/Server/Voyages.SqlDataAccess", que implementa la capa de acceso a datos y accede a la base de datos.
La base de datos utilizada es SQLite y se encuentra en la ruta "/Server/Voyages.WebApi/sqlite.db". Esta base de datos no necesita un gestor de base de datos, sino que consta únicamente de un archivo donde se almacenan los datos, al que se accede directamente desde la aplicación. Se puede abrir con DB Browser for SQLite si se quieren editar los datos. Contiene 3 tablas: Clients, Files y Products.
Los tests asociados al servicio API REST se encuentran en el proyecto de la ruta "/Server/Voyages.WebApi.Tests.Unit". También existen Test asociados al proyecto Voyages.Domain en el proyecto de la ruta "/Server/Voyages.Domain.Tests.Unit".

-2º Servidor GraphQL (Servidor):

Servidor GraphQL que recibe peticiones conjuntas de datos de clientes, dossieres de viaje o productos, y que internamente realiza peticiones separadas a los distintos servicios API REST, para luego devolverlos en una respuesta única, abstrayendo al cliente de los distintos orígenes de datos.
Esta aplicación está desarrollada con .Net Core y escrita en C#.
La ruta donde se encuentra el proyecto que implementa el servidor GraphQL es "/Server/Voyages.GraphQL.Api". 
Hace uso del proyecto "/Server/Voyages.Domain" para disponer de las diferentes Entidades, que recibe de los servicios API REST.

-3º Aplicación web React (Cliente):

Esta aplicación web simula el funcionamiento de la web de una agencia de viajes, donde en un formulario se introduce el nombre y apellido del cliente y la aplicación muestra la información del cliente, del dossier de su viaje y del producto contratado.
Esta aplicación está desarrollada con React, que usa el entorno de ejecución Node.js. A nivel de diseño, usa Bootstrap.
Para obtener los datos hace uso de Apollo, un cliente de GraphQL. Con este cliente Apollo realiza una única petición con los campos que necesita al servidor GraphQL, y con los datos recibidos renderiza el formulario con la información del cliente.
La ruta donde se encuentra es "/Client/Voyages.React".
