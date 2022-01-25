DROP DATABASE IF EXISTS labellota;
CREATE DATABASE labellota;
USE labellota;

CREATE TABLE administrador(
    administradorId         INT NOT NULL AUTO_INCREMENT,
    nombre                  VARCHAR(150) NOT NULL,
    active                  BOOLEAN NOT NULL,
    CONSTRAINT pk_administrador PRIMARY KEY(administradorId)
);

CREATE TABLE sucursal(
    sucursalId              INT NOT NULL AUTO_INCREMENT,
    nombreSucursal          VARCHAR(150) NOT NULL,
    administradorId         INT NOT NULL,
    telefono                CHAR(10) NOT NULL,
    direccion               TEXT NOT NULL,
    activa                  BOOLEAN NOT NULL, 
    CONSTRAINT pk_sucursal PRIMARY KEY(sucursalId),
    CONSTRAINT uk_sucursal UNIQUE(nombreSucursal),
    CONSTRAINT fk_sucrusal FOREIGN KEY(administradorId) REFERENCES administrador(administradorId)
);

CREATE TABLE proveedor(
    proveedorId             INT NOT NULL AUTO_INCREMENT,
    nombre                  VARCHAR(250) NOT NULL,
    telefonoFijo            CHAR(10) NOT NULL,
    telefonoMovil           CHAR(10) NOT NULL,
    email                   VARCHAR(150) NOT NULL,
    direccion               TEXT NOT NULL,
    rfc                     VARCHAR(13) NOT NULL,
    clabe                   CHAR(18) NOT NULL,
    cuenta                  VARCHAR(12),
    CONSTRAINT pk_proveedor PRIMARY KEY(proveedorId),
    CONSTRAINT uk_proveedor UNIQUE(rfc)
);

CREATE TABLE areasexhibicion(
    exhibicionId            INT NOT NULL AUTO_INCREMENT,
    nombreExhibicion        VARCHAR(100) NOT NULL,
    CONSTRAINT pk_areasexhibicion PRIMARY KEY(exhibicionId)
);

CREATE TABLE producto(
    productoId              INT NOT NULL AUTO_INCREMENT,
    nombre                  VARCHAR(100) NOT NULL,
    precio                  FLOAT NOT NULL,
    exhibicionId            INT NOT NULL,
    fechaCaducidad          DATE NOT NULL,
    proveedorId             INT NOT NULL,
    timeStamp               DATETIME,
    CONSTRAINT pk_producto PRIMARY KEY(productoId),
    CONSTRAINT fk_producto FOREIGN KEY(exhibicionId) REFERENCES areasexhibicion(exhibicionId),
    CONSTRAINT fk_productoI FOREIGN KEY(proveedorId) REFERENCES proveedor(proveedorId)
);

CREATE TABLE inventario(
    inventarioId            INT NOT NULL AUTO_INCREMENT,
    productoId              INT NOT NULL,
    sucursalId              INT NOT NULL,
    cantidad                INT NOT NULL,
    fechaCaducidad          DATE NOT NULL,
    fechaAbastecimiento     DATE NOT NULL,
    proveedorId             INT NOT NULL,
    proximoAbastecimiento   DATE NOT NULL,
    proveedorId1             INT NOT NULL,
    administradorId         INT NOT NULL,
    CONSTRAINT pk_inventario PRIMARY KEY(inventarioId),
    CONSTRAINT fk_inventario FOREIGN KEY(productoId) REFERENCES producto(productoId),
    CONSTRAINT fk_inventarioI FOREIGN KEY(sucursalId) REFERENCES sucursal(sucursalId),
    CONSTRAINT fk_inventarioII FOREIGN KEY(proveedorId) REFERENCES proveedor(proveedorId),
    CONSTRAINT fk_inventarioIII FOREIGN KEY(proveedorId1) REFERENCES proveedor(proveedorId)
);

CREATE TABLE menu(
    menuId                  INT NOT NULL AUTO_INCREMENT,
    inicioTemporada         DATE NOT NULL,
    finTemporada            DATE NOT NULL,
    CONSTRAINT pk_menu PRIMARY KEY(menuId)
);

CREATE TABLE menuitem(
    itemId                  INT NOT NULL AUTO_INCREMENT,
    menuId                  INT NOT NULL,
    productoId              INT NOT NULL,
    CONSTRAINT pk_menuitem PRIMARY KEY(itemId),
    CONSTRAINT fk_menuitem FOREIGN KEY(menuId) REFERENCES menu(menuId),
    CONSTRAINT fk_menuitemI FOREIGN KEY(productoId) REFERENCES producto(productoId)
);

CREATE TABLE usuario(
    usuarioId               VARCHAR(100) NOT NULL,
    nombre                  VARCHAR(100) NOT NULL,
    apellidos               VARCHAR(150) NOT NULL,
    telefono                CHAR(10) NOT NULL,
    email                   VARCHAR(150) NOT NULL,
    password                VARCHAR(500) NOT NULL,
    CONSTRAINT pk_usuario PRIMARY KEY(usuarioId)
);

CREATE TABLE venta(
    ventaId                 INT NOT NULL AUTO_INCREMENT,
    usuarioId               VARCHAR(100) NOT NULL,
    costo                   FLOAT NOT NULL,
    CONSTRAINT pk_venta PRIMARY KEY(ventaId),
    CONSTRAINT fk_venta FOREIGN KEY(usuarioId) REFERENCES usuario(usuarioId)
);

CREATE TABLE productoventa(
    prdVentaId              INT NOT NULL AUTO_INCREMENT,
    productoId              INT NOT NULL,
    ventaId                 INT NOT NULL,
    cantidad                INT NOT NULL,
    monto                   FLOAT NOT NULL,
    CONSTRAINT pk_productoventa PRIMARY KEY(prdVentaId),
    CONSTRAINT fk_productoventa FOREIGN KEY(productoId) REFERENCES producto(productoId),
    CONSTRAINT fk_productoventaI FOREIGN KEY(ventaId) REFERENCES venta(ventaId)
);

/*             TRIGGERS              */
DELIMITER $$
CREATE TRIGGER bi_producto BEFORE INSERT ON producto FOR EACH ROW
    BEGIN 
        SET NEW.timeStamp = NOW();
    END $$
DELIMITER ;