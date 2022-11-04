-- MySQL Script generated by MySQL Workbench
-- Thu Nov  3 21:57:08 2022
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mifactura
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mifactura
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mifactura` DEFAULT CHARACTER SET utf8 ;
USE `mifactura` ;

-- -----------------------------------------------------
-- Table `mifactura`.`Usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mifactura`.`Usuario` (
  `Codigo` NVARCHAR(20) NOT NULL,
  `Nombre` NVARCHAR(50) NOT NULL,
  `Clave` NVARCHAR(120) NOT NULL,
  `Correo` NVARCHAR(45) NULL,
  `Rol` NVARCHAR(20) NOT NULL,
  `EstaActivo` TINYINT NOT NULL,
  PRIMARY KEY (`Codigo`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mifactura`.`Producto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mifactura`.`Producto` (
  `Codigo` INT NOT NULL,
  `Descripcion` VARCHAR(50) NOT NULL,
  `Existencia` INT NOT NULL,
  `Precio` DECIMAL NOT NULL,
  `FechaCreacion` DATETIME NOT NULL,
  `Imagen` LONGBLOB NULL,
  PRIMARY KEY (`Codigo`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mifactura`.`Cliente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mifactura`.`Cliente` (
  `Identidad` VARCHAR(30) NOT NULL,
  `Nombre` VARCHAR(65) NOT NULL,
  `Direccion` VARCHAR(100) NULL,
  `Email` VARCHAR(40) NULL,
  `Telefono` VARCHAR(20) NULL,
  PRIMARY KEY (`Identidad`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mifactura`.`Factura`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mifactura`.`Factura` (
  `Id` INT NOT NULL,
  `IdentidadCliente` VARCHAR(30) NOT NULL,
  `Fechal` DATETIME NOT NULL,
  `CodigoUsuario` NVARCHAR(20) NOT NULL,
  `ISV` DECIMAL(8,2) NULL,
  `Descuento` DECIMAL(8,2) NULL,
  `SubTotal` DECIMAL(8,2) NULL,
  `Total` DECIMAL(8,2) NULL,
  PRIMARY KEY (`Id`),
  INDEX `FK_Factura_Cliente_idx` (`IdentidadCliente` ASC) VISIBLE,
  INDEX `FK_Factura_Usuario_idx` (`CodigoUsuario` ASC) VISIBLE,
  CONSTRAINT `FK_Factura_Cliente`
    FOREIGN KEY (`IdentidadCliente`)
    REFERENCES `mifactura`.`Cliente` (`Identidad`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Factura_Usuario`
    FOREIGN KEY (`CodigoUsuario`)
    REFERENCES `mifactura`.`Usuario` (`Codigo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mifactura`.`DetalleFactura`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mifactura`.`DetalleFactura` (
  `Id` INT NOT NULL,
  `IdFactura` INT NOT NULL,
  `CodigoProducto` INT NOT NULL,
  `Precio` DECIMAL(8,2) NULL,
  `Cantidad` INT NULL,
  `Total` DECIMAL(8,2) NULL,
  PRIMARY KEY (`Id`),
  INDEX `FK_DetaFact_Factura_idx` (`IdFactura` ASC) VISIBLE,
  INDEX `FK_DetaFact_Producto_idx` (`CodigoProducto` ASC) VISIBLE,
  CONSTRAINT `FK_DetaFact_Factura`
    FOREIGN KEY (`IdFactura`)
    REFERENCES `mifactura`.`Factura` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_DetaFact_Producto`
    FOREIGN KEY (`CodigoProducto`)
    REFERENCES `mifactura`.`Producto` (`Codigo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
