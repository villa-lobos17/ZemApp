# ZemApp
Repo Zemoga test Jorge Villalobos villa-lobos17@hotmail.com

### Arquitectura de dise;o
para esta prueba se uso la arquitectura orientada a dominio o DDD la razon para usarlo fue la facilidad de ser comprendido y ser mas cercano al cliente *fue pensado para no romper la cabeza del revisor de la prueba* ademas de la facilidad para implementar pruebas unitarias,y lo cercano que puede ser para la resolucion del problema planteado en la prueba.

![alt text](https://raw.githubusercontent.com/villa-lobos17/ZemApp/main/DDD_png_pure0.png)

se tuvieron en cuenta tras arquitecturas como clean onion y N capas.

### Estructura del codigo
El codigo esta estructurado en las siguientes proyectos:
* Cliente : Zemapp.Api
* Capa de Aplicacion : Zemapp.Application
* Capa de Dominio: Zemapp.Domain
* Capa de Infraestructura : Zemapp:Infrastructure

el codigo del cliente esta estructurado en 2 partes en el mismo proyecto teniendo en cuenta que el codigo cliente es .Net core y el codigo de la vista se encuentra en la carpeta ** ClientApp ** 

![alt text](https://raw.githubusercontent.com/villa-lobos17/ZemApp/main/client.PNG)



### Requerimientos de la prueba
este codigo ha sido desarrollado con .Net Core 3.1  Angular *(usando la ultima version de angular cli)* y como storage de datos se uso MongoDB los requisitos para depurar este codigo son :

* MongoDB client *Community Server Edition *  https://www.mongodb.com/try/download/community 
* Node Js 14 + https://nodejs.org/es/
* Visual studio 2017 /2019
* git-bash o vscode
* .Net core 3.1
* Angular cli - Last version https://cli.angular.io/ 

### Datos de despliegue
para poder correr la prueba se debe abrir con visual studio y compilar , si en caso de presentarse algun error al compilar el codigo en front seria necesario seguir los siguientes pasos:
* ir a la carpeta /ZemApp.Api/ClientApp
* sobre esa carpeta abrir una consola de git-bash o vscode terminal
* Ejecutar el comando npm install
* Ejecutar el comando ng build
* Intente correr el codigo de nuevo

### Datos de Acceso de la Prueba

** 
Usuario Editor **
* Email : terminator@gmail.com
* Password : AB1234
</br>
** Usuario Escritor **

* Email : Jhon.connor@gmail.com 
* Password : AB1234

### Desarrollo punto 1
La prueba no requiere de correr scripts, apenas esta inicie redirige al usuario al home de los post, teniendo las opciones solicitadas en el punto 1 




### Desarrollo punto 2
esta prueba integra swagger para los test del proyecto accediendo a la Url http://localhost:3907/swagger/index.html
![alt text](https://raw.githubusercontent.com/villa-lobos17/ZemApp/main/swa10.PNG)

el endpoint para realizar la consulta de los post pendientes es :
http://localhost:3907/api/BlogPost/query

el endpoint para realizar la actualizacion  de los post pendientes es :
http://localhost:3907/api/BlogPost/approval


