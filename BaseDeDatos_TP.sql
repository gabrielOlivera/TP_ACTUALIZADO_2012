-- MySQL dump 10.13  Distrib 5.5.15, for Win32 (x86)
--
-- Host: localhost    Database: tp base de datos
-- ------------------------------------------------------
-- Server version	5.5.17

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `tp base de datos`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `tp base de datos` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `tp base de datos`;

--
-- Table structure for table `bloque`
--

DROP TABLE IF EXISTS `bloque`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bloque` (
  `idBloque` int(11) NOT NULL AUTO_INCREMENT,
  `nroBloque` int(11) NOT NULL,
  `Cuestionario_idCuestrionario` int(11) NOT NULL,
  `esUltimoBloque` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`idBloque`),
  UNIQUE KEY `idBloque_UNIQUE` (`idBloque`),
  KEY `fk_idCuestionario` (`Cuestionario_idCuestrionario`),
  CONSTRAINT `fk_idCuestionario` FOREIGN KEY (`Cuestionario_idCuestrionario`) REFERENCES `cuestionario` (`idCuestionario`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bloque`
--

LOCK TABLES `bloque` WRITE;
/*!40000 ALTER TABLE `bloque` DISABLE KEYS */;
/*!40000 ALTER TABLE `bloque` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `candidato`
--

DROP TABLE IF EXISTS `candidato`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `candidato` (
  `idCandidato` int(11) NOT NULL AUTO_INCREMENT,
  `nroEmpleado` int(11) DEFAULT NULL,
  `nroCandidato` int(11) DEFAULT NULL,
  `tipo documento` varchar(3) NOT NULL,
  `nro documento` varchar(10) NOT NULL,
  `nombre` varchar(45) NOT NULL,
  `apellido` varchar(45) NOT NULL,
  `fechaNacimiento` date NOT NULL,
  `nacionalidad` varchar(45) NOT NULL,
  `genero` varchar(20) NOT NULL,
  `e-mail` varchar(100) DEFAULT NULL,
  `escolaridad` varchar(45) DEFAULT NULL,
  `eliminado` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`idCandidato`),
  UNIQUE KEY `nro documento_UNIQUE` (`nro documento`),
  UNIQUE KEY `nroEmpleado_UNIQUE` (`nroEmpleado`),
  UNIQUE KEY `nroCandidato_UNIQUE` (`nroCandidato`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1 PACK_KEYS=1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `candidato`
--

LOCK TABLES `candidato` WRITE;
/*!40000 ALTER TABLE `candidato` DISABLE KEYS */;
INSERT INTO `candidato` VALUES (1,NULL,1,'DNI','32376056','JOSE','PICCICIONI','1989-05-23','ARGENTINA','M',NULL,'TERCIARIO',NULL),(2,NULL,5,'DNI','34823666','NICOLAS','BIELER','1980-02-12','ARGENTINO','M',NULL,'TERCIARIO',NULL),(3,NULL,25,'DNI','32558698','ANA','CONDA','1982-03-26','ARGENTINA','F',NULL,'UNIVERSITARIO',NULL),(4,NULL,10,'DNI','33856125','MARIA CLARA','MONTOYA','1988-05-12','ARGENTINA','F',NULL,'SECUNDARIO',NULL),(5,12,NULL,'DNI','33125456','MARCOS','ALVAREZ','1987-06-30','ARGENTINO','M',NULL,'TERCIARIO',NULL),(6,NULL,99,'DNI','31256896','PENELOPE','GUINESS','1986-02-15','ARGENTINA','F',NULL,'TERCIARIO',NULL),(7,5,NULL,'PP','P321526352','NICK','WAHLBERG','1985-07-22','EE.UU','M',NULL,'TERCIARIO',NULL),(8,NULL,65,'PP','L352625684','ED','CHASE','1986-05-15','EE.UU','M',NULL,'TERCIARIO',NULL),(9,NULL,15,'DNI','34896587','JENNIFER','DAVIS','1990-11-23','ARGENTINA','F',NULL,'SECUNDARIO',NULL),(10,NULL,2,'PP','U223562158','WALTER','DIAZ','1987-10-11','URUGUAYO','M',NULL,'TERCIARIO',NULL),(11,NULL,16,'DNI','33263561','CARLOS','FRANCO','1988-12-23','ARGENTINO','M',NULL,'TERCIARIO',NULL),(12,23,NULL,'DNI','31962352','PAMELA','MONTOYA','1985-09-24','ARGENTINA','F',NULL,'TERCIARIO',NULL),(13,NULL,3,'DNI','32635126','MARIELA','PILA','1983-02-02','ARGENTINA','F',NULL,'UNIVERSITARIO',NULL),(14,2,NULL,'DNI','34562415','PABLO','SERRA','1988-12-31','ARGENTINO','M',NULL,'TERCIARIO',NULL),(15,NULL,41,'PP','U263526235','JUAN','PEREZ','1985-06-25','URUGUAYO','M',NULL,'TERCIARIO',NULL);
/*!40000 ALTER TABLE `candidato` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `competencia`
--

DROP TABLE IF EXISTS `competencia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `competencia` (
  `codigo` varchar(20) NOT NULL,
  `nombre` varchar(45) NOT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  `eliminado` tinyint(1) DEFAULT NULL,
  `fecha y hora` datetime DEFAULT NULL,
  `Consultor_nroEmpleado` int(11) DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `codigo_UNIQUE` (`codigo`),
  KEY `fk_Competencia_Consultor1` (`Consultor_nroEmpleado`),
  CONSTRAINT `fk_Competencia_Consultor1` FOREIGN KEY (`Consultor_nroEmpleado`) REFERENCES `consultor` (`nroEmpleado`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `competencia`
--

LOCK TABLES `competencia` WRITE;
/*!40000 ALTER TABLE `competencia` DISABLE KEYS */;
INSERT INTO `competencia` VALUES ('C00','GESTION DE PROYECTOS','INTERES E INVESTIGACION DE POSIBLES NUEVOS PROYECTOS',NULL,NULL,NULL),('C01','ADMISTRACION RR HH',NULL,NULL,NULL,NULL),('C02','DISEÑO DE SISTEMAS','DESARROLLO DE MODELOS DE SISTEMAS, MODELOS DE ANALISIS, MODELOS DE IMPLEMENTACION',NULL,NULL,NULL),('C03','CONOCIMIENTOS GENERALES PROGRAMACION','LENGUAGES DE PROGRAMACION PARA DESARROLLOS ',NULL,NULL,NULL),('C04','LENGUA EXTANGERA','CONOCIMIENTOS DE INGLES',NULL,NULL,NULL),('C05','DESARROLLO Y PROGRAMACION','HABILIDADES Y CONOCIMIENTOS EN DIFERENTES PLATAFORMAS',NULL,NULL,NULL);
/*!40000 ALTER TABLE `competencia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `competencia evaluada`
--

DROP TABLE IF EXISTS `competencia evaluada`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `competencia evaluada` (
  `idCompetencia Evaluada` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(20) NOT NULL,
  `nombre` varchar(45) NOT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  `eliminado` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`idCompetencia Evaluada`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `competencia evaluada`
--

LOCK TABLES `competencia evaluada` WRITE;
/*!40000 ALTER TABLE `competencia evaluada` DISABLE KEYS */;
/*!40000 ALTER TABLE `competencia evaluada` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `consultor`
--

DROP TABLE IF EXISTS `consultor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `consultor` (
  `nroEmpleado` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  `apellido` varchar(45) NOT NULL,
  PRIMARY KEY (`nroEmpleado`),
  UNIQUE KEY `idConsultor_UNIQUE` (`nroEmpleado`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `consultor`
--

LOCK TABLES `consultor` WRITE;
/*!40000 ALTER TABLE `consultor` DISABLE KEYS */;
INSERT INTO `consultor` VALUES (1,'Jos','Piccioni'),(2,'Nicolas','Bieler'),(3,'Gabriel','Piedrabuena');
/*!40000 ALTER TABLE `consultor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cuestionario`
--

DROP TABLE IF EXISTS `cuestionario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cuestionario` (
  `idCuestionario` int(11) NOT NULL AUTO_INCREMENT,
  `clave` varchar(20) NOT NULL,
  `nroAccesos` int(11) NOT NULL,
  `Puesto Evaluado_idPuesto Evaluado` int(11) NOT NULL,
  `Candidato_idCandidato` int(11) NOT NULL,
  `ultimoBloque` int(11) DEFAULT NULL,
  PRIMARY KEY (`idCuestionario`),
  UNIQUE KEY `idCuestionario_UNIQUE` (`idCuestionario`),
  UNIQUE KEY `clave_UNIQUE` (`clave`),
  KEY `fk_Cuestionario_Puesto Evaluado1` (`Puesto Evaluado_idPuesto Evaluado`),
  KEY `fk_Cuestionario_Candidato1` (`Candidato_idCandidato`),
  CONSTRAINT `fk_Cuestionario_Candidato1` FOREIGN KEY (`Candidato_idCandidato`) REFERENCES `candidato` (`idCandidato`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Cuestionario_Puesto Evaluado1` FOREIGN KEY (`Puesto Evaluado_idPuesto Evaluado`) REFERENCES `puesto evaluado` (`idPuesto Evaluado`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cuestionario`
--

LOCK TABLES `cuestionario` WRITE;
/*!40000 ALTER TABLE `cuestionario` DISABLE KEYS */;
/*!40000 ALTER TABLE `cuestionario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cuestionario_estado`
--

DROP TABLE IF EXISTS `cuestionario_estado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cuestionario_estado` (
  `Cuestionario_idCuestionario` int(11) NOT NULL,
  `Estado_idEstado` int(11) NOT NULL,
  `fecha` datetime NOT NULL,
  PRIMARY KEY (`Cuestionario_idCuestionario`,`Estado_idEstado`,`fecha`),
  KEY `fk_Cuestionario_has_Estado_Estado1` (`Estado_idEstado`),
  KEY `fk_Cuestionario_has_Estado_Cuestionario1` (`Cuestionario_idCuestionario`),
  CONSTRAINT `fk_Cuestionario_has_Estado_Cuestionario1` FOREIGN KEY (`Cuestionario_idCuestionario`) REFERENCES `cuestionario` (`idCuestionario`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Cuestionario_has_Estado_Estado1` FOREIGN KEY (`Estado_idEstado`) REFERENCES `estado` (`idEstado`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cuestionario_estado`
--

LOCK TABLES `cuestionario_estado` WRITE;
/*!40000 ALTER TABLE `cuestionario_estado` DISABLE KEYS */;
/*!40000 ALTER TABLE `cuestionario_estado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `estado`
--

DROP TABLE IF EXISTS `estado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `estado` (
  `idEstado` int(11) NOT NULL AUTO_INCREMENT,
  `estado` varchar(14) NOT NULL,
  PRIMARY KEY (`idEstado`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `estado`
--

LOCK TABLES `estado` WRITE;
/*!40000 ALTER TABLE `estado` DISABLE KEYS */;
INSERT INTO `estado` VALUES (1,'ACTIVO'),(2,'EN PROCESO'),(3,'SIN CONTESTAR'),(4,'INCOMPLETO'),(5,'COMPLETO');
/*!40000 ALTER TABLE `estado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `factor`
--

DROP TABLE IF EXISTS `factor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `factor` (
  `codigo` varchar(20) NOT NULL,
  `nombre` varchar(45) NOT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  `nroOrden` int(11) NOT NULL,
  `Competencia_codigo` varchar(20) NOT NULL,
  `eliminado` tinyint(1) DEFAULT NULL,
  `fecha y hora` datetime DEFAULT NULL,
  `Consultor_nroEmpleado` int(11) DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `codigo_UNIQUE` (`codigo`),
  KEY `fk_Factor_Competencia1` (`Competencia_codigo`),
  KEY `fk_Factor_Consultor1` (`Consultor_nroEmpleado`),
  CONSTRAINT `fk_Factor_Competencia1` FOREIGN KEY (`Competencia_codigo`) REFERENCES `competencia` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Factor_Consultor1` FOREIGN KEY (`Consultor_nroEmpleado`) REFERENCES `consultor` (`nroEmpleado`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factor`
--

LOCK TABLES `factor` WRITE;
/*!40000 ALTER TABLE `factor` DISABLE KEYS */;
INSERT INTO `factor` VALUES ('F00','GESTION DEL TIEMPO',NULL,2,'C00',NULL,NULL,NULL),('F01','GESTION DEL ALCANCE',NULL,1,'C00',NULL,NULL,NULL),('F02','CONOCIMIENTOS DE MODELOS',NULL,1,'C02',NULL,NULL,NULL),('F03','CONOCIMIENTOS INGLES TECNICO',NULL,1,'C04',NULL,NULL,NULL),('F04','CONOCIMIENTOS INGLES AVANZADOS',NULL,2,'C04',NULL,NULL,NULL),('F05','ESTABILIDAD LABORAL','CUANTOS TRABAJOS ANTERIORES TUVO',1,'C01',NULL,NULL,NULL),('F07','PRODUCTIVIDAD DEL PERSONAL',NULL,2,'C01',NULL,NULL,NULL),('F08','GESTION DEL TIEMPO',NULL,3,'C01',NULL,NULL,NULL),('F09','INTERPRETACION DE MODELOS',NULL,2,'C02',NULL,NULL,NULL),('F10','CONOCIMIENTOS GENERALES',NULL,3,'C02',NULL,NULL,NULL),('F11','PROGRAMACION ESTRUCTURAL','EN LENGUAJES COMO C O PHYTON',1,'C03',NULL,NULL,NULL),('F12','BUENAS PRACTICAS',NULL,2,'C03',NULL,NULL,NULL),('F13','PROGRAMACION EN OBJETOS','C++, JAVA, PHARO, SMALTALK',3,'C03',NULL,NULL,NULL),('F14','MANTENIMIENTO SOFTWARE',NULL,1,'C05',NULL,NULL,NULL),('F15','PLATAFORMAS DE PROGRAMACION',NULL,2,'C05',NULL,NULL,NULL);
/*!40000 ALTER TABLE `factor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `factor evaluado`
--

DROP TABLE IF EXISTS `factor evaluado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `factor evaluado` (
  `idFactor Evaluado` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(20) NOT NULL,
  `nombre` varchar(45) NOT NULL,
  `nroOrden` int(11) NOT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  `Competencia Evaluada_idCompetencia Evaluada` int(11) NOT NULL,
  `eliminado` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`idFactor Evaluado`),
  KEY `fk_Factor Evaluado_Competencia Evaluada1` (`Competencia Evaluada_idCompetencia Evaluada`),
  CONSTRAINT `fk_Factor Evaluado_Competencia Evaluada1` FOREIGN KEY (`Competencia Evaluada_idCompetencia Evaluada`) REFERENCES `competencia evaluada` (`idCompetencia Evaluada`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factor evaluado`
--

LOCK TABLES `factor evaluado` WRITE;
/*!40000 ALTER TABLE `factor evaluado` DISABLE KEYS */;
/*!40000 ALTER TABLE `factor evaluado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `instrucciones de sistema`
--

DROP TABLE IF EXISTS `instrucciones de sistema`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `instrucciones de sistema` (
  `idInstrucciones de Sistema` int(11) NOT NULL AUTO_INCREMENT,
  `preguntasPorBloque` int(11) NOT NULL,
  `tiempoEstadoActivo` int(11) NOT NULL,
  `tiempoParaContestarCuestionario` int(11) NOT NULL,
  `maximosAccesos` int(11) NOT NULL,
  `instruccionesDelcuestionario` varchar(1000) NOT NULL,
  PRIMARY KEY (`idInstrucciones de Sistema`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `instrucciones de sistema`
--

LOCK TABLES `instrucciones de sistema` WRITE;
/*!40000 ALTER TABLE `instrucciones de sistema` DISABLE KEYS */;
INSERT INTO `instrucciones de sistema` VALUES (1,5,60,60,4,'INSTRUCCIONES: @@1) Presione \'Aceptar\' luego de haber leído estas instrucciones para dar comienzo a su evaluación. @Después de esto se les presentara en la pantalla un bloque con preguntas, y se dará inicio a su evaluación. @@2) Lea atentamente las preguntas y conteste una solo opción por cada una. @Recuerde que solo pude haber una sola opción contestada y no podrá dejar una pregunta sin su correspondiente respuesta. @@3) Verifique sus respuestas antes de presionar \'siguiente\'. @No podrá volver a ver el bloque de preguntas una vez pasado al siguiente bloque. @@4) Recuerde que tiene un límite de accesos a realizar el cuestionario. Máximo de accesos es');
/*!40000 ALTER TABLE `instrucciones de sistema` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `item_bloque`
--

DROP TABLE IF EXISTS `item_bloque`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `item_bloque` (
  `idbloque_preguntaev` int(11) NOT NULL AUTO_INCREMENT,
  `Bloque_idBloque` int(11) NOT NULL,
  `PreguntaEvaluada_idPreguntaEv` int(11) NOT NULL,
  `Opcion Evaluada_idOpcion_seleccionada` int(11) DEFAULT NULL,
  PRIMARY KEY (`idbloque_preguntaev`),
  KEY `fk_preguntaevaluada` (`PreguntaEvaluada_idPreguntaEv`),
  KEY `fk_bloque` (`Bloque_idBloque`),
  KEY `fk_opcionevaluada` (`Opcion Evaluada_idOpcion_seleccionada`),
  CONSTRAINT `fk_bloque` FOREIGN KEY (`Bloque_idBloque`) REFERENCES `bloque` (`idBloque`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_opcionevaluada` FOREIGN KEY (`Opcion Evaluada_idOpcion_seleccionada`) REFERENCES `opcion evaluada` (`idOpcion`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `item_bloque`
--

LOCK TABLES `item_bloque` WRITE;
/*!40000 ALTER TABLE `item_bloque` DISABLE KEYS */;
/*!40000 ALTER TABLE `item_bloque` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `opcion de respuesta`
--

DROP TABLE IF EXISTS `opcion de respuesta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `opcion de respuesta` (
  `codigo` varchar(20) NOT NULL,
  `nombre` varchar(20) NOT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  `eliminado` tinyint(1) DEFAULT NULL,
  `fecha y hora` datetime DEFAULT NULL,
  `Consultor_nroEmpleado` int(11) DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  KEY `fk_Opcion de Respuesta_Consultor1` (`Consultor_nroEmpleado`),
  CONSTRAINT `fk_Opcion de Respuesta_Consultor1` FOREIGN KEY (`Consultor_nroEmpleado`) REFERENCES `consultor` (`nroEmpleado`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `opcion de respuesta`
--

LOCK TABLES `opcion de respuesta` WRITE;
/*!40000 ALTER TABLE `opcion de respuesta` DISABLE KEYS */;
INSERT INTO `opcion de respuesta` VALUES ('OR200','SI-NO-NS/NC',NULL,NULL,NULL,NULL),('OR201','SI-NO',NULL,NULL,NULL,NULL),('OR202','ESCALA A EXCELENTE','OPCIONES MALO - REGULAR - BUENO - MUY BUENO - EXCELENTE',NULL,NULL,NULL),('OR203','ESCALA A SIEMPRE','OPCIONES DEPENDE - A VECES - SIEMPRE -NUNCA',NULL,NULL,NULL),('OR204','BUENO - MUY BUENO',NULL,NULL,NULL,NULL),('OR205','ESCALA 1 - 10',NULL,NULL,NULL,NULL),('OR206','A EXCELENTE + N ANT','ESCALA A EXCELENTE CON NINGUNA DE LAS ANTERIORES',NULL,NULL,NULL),('OR207','A SIEMPRE + N. ANT.','ESCALA A SIMPRE CON NINGUNA DE LAS ANTERIORES',NULL,NULL,NULL),('OR208','S.O. 1','WINDOWS - LINUX - MAC',NULL,NULL,NULL),('OR209','S.O. 2','S.O 1 + ANDROY',NULL,NULL,NULL),('OR210','LENGUAJES 1','PHP - HTML - C# - JAVA SCRIP',NULL,NULL,NULL),('OR211','LENGUAJES 2','C++ - C# - JAVA - SMALLTALK',NULL,NULL,NULL),('OR212','LENGUAJES 3','PHYTON - PROLOG - FOLTRAN - DR SCHEME',NULL,NULL,NULL),('OR213','LENGUAJES 1 + N. ANT','LENG 1 CON NINGUNA DE LAS ANTERIORES',NULL,NULL,NULL),('OR214','LENGUAJES 2 + N. ANT','LENG 2 CON NINGUNA DE LAS ANTERIORES',NULL,NULL,NULL),('OR215','LENGUAJES 3 + N. ANT','LENG 3 CON NINGUNA DE LAS ANTERIORES',NULL,NULL,NULL),('OR216','S.O 1 + N. ANT','SISTEMAS OPERATIVOS 1 CON NINGUNA DE LAS ANTERIORES',NULL,NULL,NULL),('OR217','S.O 2 + N ANT','SIST OPERATIVOS 2 CON NING. DE LAS ANTERIORES',NULL,NULL,NULL),('OR218','ESCALA 1-4 + MAS','ESCALA NUMERICA CON LA OPCION \"MAS\"',NULL,NULL,NULL),('OR219','DEPENDENCIAS PROYEC','DEPENDENCIAS EN LOS PROYECTOS',NULL,NULL,NULL),('OR220','INGLES 1','OPCIONES PUNTUALES PARA LA PREGUNTA PR40',NULL,NULL,NULL),('OR221','INGLES 2','OPCIONES PUNTUALES PARA LA PREGUNTA PR41',NULL,NULL,NULL),('OR222','INGLES 3','OPCIONES PUNTUALES PARA LA PREGUNTA PR42',NULL,NULL,NULL),('OR223','INGLES 4','OPCIONES PUNTUALES PARA LA PREGUNTA PR43',NULL,NULL,NULL),('OR224','INGLES 5','OPCIONES PUNTUALES PARA LA PREGUNTA PR44',NULL,NULL,NULL);
/*!40000 ALTER TABLE `opcion de respuesta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `opcion de respuesta evaluada`
--

DROP TABLE IF EXISTS `opcion de respuesta evaluada`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `opcion de respuesta evaluada` (
  `idOpcion de Respuesta Evaluada` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(20) NOT NULL,
  `nombre` varchar(45) NOT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  `eliminado` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`idOpcion de Respuesta Evaluada`),
  UNIQUE KEY `idOpcion de Respuesta Evaluada_UNIQUE` (`idOpcion de Respuesta Evaluada`),
  UNIQUE KEY `nombre_UNIQUE` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `opcion de respuesta evaluada`
--

LOCK TABLES `opcion de respuesta evaluada` WRITE;
/*!40000 ALTER TABLE `opcion de respuesta evaluada` DISABLE KEYS */;
INSERT INTO `opcion de respuesta evaluada` VALUES (1,'OR200','SI-NO-NS/NC',NULL,NULL),(2,'OR201','SI-NO',NULL,NULL),(3,'OR203','ESCALA A SIEMPRE',NULL,NULL),(4,'OR205','ESCALA 1 - 10',NULL,NULL),(5,'OR207','A SIEMPRE + N. ANT.',NULL,NULL),(6,'OR211','LENGUAJES 2',NULL,NULL),(7,'OR214','LENGUAJES 2 + N. ANT',NULL,NULL),(8,'OR216','S.O 1 + N. ANT',NULL,NULL),(9,'OR218','ESCALA 1-4 + MAS',NULL,NULL),(10,'OR219','DEPENDENCIAS PROYEC',NULL,NULL),(11,'OR220','INGLES 1',NULL,NULL),(12,'OR221','INGLES 2',NULL,NULL),(13,'OR222','INGLES 3',NULL,NULL),(14,'OR223','INGLES 4',NULL,NULL),(15,'OR224','INGLES 5',NULL,NULL),(16,'OR202','ESCALA A EXCELENTE',NULL,NULL),(17,'OR204','BUENO - MUY BUENO',NULL,NULL),(18,'OR206','A EXCELENTE + N ANT',NULL,NULL),(19,'OR208','S.O. 1',NULL,NULL),(20,'OR209','S.O. 2',NULL,NULL),(21,'OR210','LENGUAJES 1',NULL,NULL),(22,'OR212','LENGUAJES 3',NULL,NULL),(23,'OR213','LENGUAJES 1 + N. ANT',NULL,NULL),(24,'OR215','LENGUAJES 3 + N. ANT',NULL,NULL),(25,'OR217','S.O 2 + N. ANT',NULL,NULL);
/*!40000 ALTER TABLE `opcion de respuesta evaluada` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `opcion de respuesta evaluada_opcion evaluada`
--

DROP TABLE IF EXISTS `opcion de respuesta evaluada_opcion evaluada`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `opcion de respuesta evaluada_opcion evaluada` (
  `Opcion Evaluada_idOpcion` int(11) NOT NULL,
  `Opcion de Respuesta Evaluada_idOpcion de Respuesta Evaluada` int(11) NOT NULL,
  `ordenDeVisualizacion` int(11) NOT NULL,
  PRIMARY KEY (`Opcion Evaluada_idOpcion`,`Opcion de Respuesta Evaluada_idOpcion de Respuesta Evaluada`),
  KEY `fk_Opcion Evaluada_has_Opcion de Respuesta Evaluada_Opcion de1` (`Opcion de Respuesta Evaluada_idOpcion de Respuesta Evaluada`),
  KEY `fk_Opcion Evaluada_has_Opcion de Respuesta Evaluada_Opcion Ev1` (`Opcion Evaluada_idOpcion`),
  CONSTRAINT `fk_Opcion Evaluada_has_Opcion de Respuesta Evaluada_Opcion de1` FOREIGN KEY (`Opcion de Respuesta Evaluada_idOpcion de Respuesta Evaluada`) REFERENCES `opcion de respuesta evaluada` (`idOpcion de Respuesta Evaluada`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Opcion Evaluada_has_Opcion de Respuesta Evaluada_Opcion Ev1` FOREIGN KEY (`Opcion Evaluada_idOpcion`) REFERENCES `opcion evaluada` (`idOpcion`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `opcion de respuesta evaluada_opcion evaluada`
--

LOCK TABLES `opcion de respuesta evaluada_opcion evaluada` WRITE;
/*!40000 ALTER TABLE `opcion de respuesta evaluada_opcion evaluada` DISABLE KEYS */;
INSERT INTO `opcion de respuesta evaluada_opcion evaluada` VALUES (1,1,1),(1,2,1),(2,1,2),(2,2,2),(3,1,3),(4,4,1),(4,9,1),(5,4,2),(5,9,2),(6,4,3),(6,9,3),(7,4,4),(7,9,4),(8,4,5),(9,4,6),(10,4,7),(11,4,8),(12,4,9),(13,4,10),(14,3,1),(14,5,1),(15,3,2),(15,5,2),(16,3,3),(16,5,3),(17,3,4),(17,5,4),(18,9,5),(19,5,5),(19,7,5),(19,8,4),(19,18,6),(19,23,5),(19,24,5),(19,25,5),(20,10,1),(21,10,2),(22,10,3),(23,10,4),(24,11,1),(25,11,2),(26,11,3),(27,11,4),(28,12,1),(29,12,2),(30,12,3),(31,13,1),(32,13,2),(33,13,3),(34,13,4),(35,14,1),(36,14,2),(37,14,3),(38,14,4),(39,15,1),(40,15,2),(41,15,3),(42,15,4),(43,6,1),(43,7,1),(44,6,2),(44,7,2),(45,6,3),(45,7,3),(45,21,3),(45,23,2),(46,6,4),(46,7,4),(47,8,1),(47,19,1),(47,20,1),(47,25,1),(48,8,2),(48,19,2),(48,20,2),(48,25,3),(49,8,3),(49,19,3),(49,20,4),(49,25,2),(50,16,1),(50,18,1),(51,16,2),(51,18,2),(52,16,3),(52,17,1),(52,18,3),(53,16,4),(53,17,2),(53,18,4),(54,16,5),(54,18,5),(58,20,3),(58,25,4),(63,22,1),(63,24,1),(64,22,3),(64,24,2),(65,21,1),(65,23,1),(66,21,2),(66,23,3),(68,21,4),(68,23,4),(69,22,4),(69,24,3),(70,22,2),(70,24,4);
/*!40000 ALTER TABLE `opcion de respuesta evaluada_opcion evaluada` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `opcion de respuesta_opciones`
--

DROP TABLE IF EXISTS `opcion de respuesta_opciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `opcion de respuesta_opciones` (
  `Opcion de Respuesta_codigo` varchar(20) NOT NULL,
  `Opciones_idopciones` int(11) NOT NULL,
  `ordenDeVisualizacion` int(11) NOT NULL,
  PRIMARY KEY (`Opcion de Respuesta_codigo`,`Opciones_idopciones`),
  KEY `fk_Opcion de Respuesta_has_Opciones_Opciones1` (`Opciones_idopciones`),
  KEY `fk_Opcion de Respuesta_has_Opciones_Opcion de Respuesta1` (`Opcion de Respuesta_codigo`),
  CONSTRAINT `fk_Opcion de Respuesta_has_Opciones_Opcion de Respuesta1` FOREIGN KEY (`Opcion de Respuesta_codigo`) REFERENCES `opcion de respuesta` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Opcion de Respuesta_has_Opciones_Opciones1` FOREIGN KEY (`Opciones_idopciones`) REFERENCES `opciones` (`idopciones`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `opcion de respuesta_opciones`
--

LOCK TABLES `opcion de respuesta_opciones` WRITE;
/*!40000 ALTER TABLE `opcion de respuesta_opciones` DISABLE KEYS */;
INSERT INTO `opcion de respuesta_opciones` VALUES ('OR200',1,1),('OR200',2,2),('OR200',3,3),('OR201',1,1),('OR201',2,2),('OR202',4,1),('OR202',5,2),('OR202',6,3),('OR202',7,4),('OR202',8,5),('OR203',9,1),('OR203',10,4),('OR203',11,3),('OR203',12,2),('OR204',6,1),('OR204',7,2),('OR205',13,1),('OR205',14,2),('OR205',15,3),('OR205',16,4),('OR205',17,5),('OR205',18,6),('OR205',19,7),('OR205',20,8),('OR205',21,9),('OR205',22,10),('OR206',4,2),('OR206',5,3),('OR206',6,4),('OR206',7,5),('OR206',8,6),('OR206',50,1),('OR207',9,1),('OR207',10,2),('OR207',11,3),('OR207',12,4),('OR207',50,5),('OR208',24,3),('OR208',26,1),('OR208',29,2),('OR209',24,2),('OR209',26,1),('OR209',27,3),('OR209',28,4),('OR209',29,5),('OR209',30,6),('OR210',34,1),('OR210',40,2),('OR210',41,3),('OR210',43,4),('OR211',32,1),('OR211',33,2),('OR211',34,3),('OR211',39,4),('OR212',37,1),('OR212',38,4),('OR212',44,2),('OR212',45,3),('OR213',34,1),('OR213',40,2),('OR213',41,3),('OR213',43,4),('OR213',50,5),('OR214',32,1),('OR214',33,2),('OR214',34,3),('OR214',39,4),('OR214',50,5),('OR215',37,1),('OR215',38,2),('OR215',44,3),('OR215',45,4),('OR215',50,5),('OR216',24,1),('OR216',26,2),('OR216',29,3),('OR216',50,4),('OR217',24,1),('OR217',26,2),('OR217',27,3),('OR217',28,4),('OR217',29,5),('OR217',30,6),('OR217',50,7),('OR218',13,1),('OR218',14,2),('OR218',15,3),('OR218',16,4),('OR218',51,5),('OR219',52,1),('OR219',53,2),('OR219',54,3),('OR219',55,4),('OR220',56,1),('OR220',57,2),('OR220',58,3),('OR220',59,4),('OR221',60,1),('OR221',61,2),('OR221',62,3),('OR222',63,1),('OR222',64,2),('OR222',65,4),('OR222',66,3),('OR223',67,1),('OR223',68,2),('OR223',69,3),('OR223',70,4),('OR224',71,1),('OR224',72,2),('OR224',73,3),('OR224',74,4);
/*!40000 ALTER TABLE `opcion de respuesta_opciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `opcion evaluada`
--

DROP TABLE IF EXISTS `opcion evaluada`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `opcion evaluada` (
  `idOpcion` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  PRIMARY KEY (`idOpcion`),
  UNIQUE KEY `nombre_UNIQUE` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=75 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `opcion evaluada`
--

LOCK TABLES `opcion evaluada` WRITE;
/*!40000 ALTER TABLE `opcion evaluada` DISABLE KEYS */;
INSERT INTO `opcion evaluada` VALUES (4,'1'),(13,'10'),(5,'2'),(6,'3'),(7,'4'),(8,'5'),(9,'6'),(10,'7'),(11,'8'),(12,'9'),(16,'A VECES'),(58,'ANDROID'),(74,'AÑOS'),(34,'are'),(52,'BUENO'),(61,'C'),(45,'C #'),(44,'C ++'),(29,'come '),(14,'DEPENDE'),(71,'DIAS'),(31,'did'),(69,'DR SCHEME'),(54,'EXCELENTE'),(67,'F#'),(64,'FORTRAN'),(66,'HTML'),(43,'JAVA'),(68,'JAVA SCRIPT'),(49,'LINUX'),(48,'MAC OS'),(50,'MALO'),(18,'MAS'),(72,'MESES'),(60,'MS - DOS'),(53,'MUY BUENO'),(19,'NINGUNA ANTERIORES'),(2,'NO'),(23,'NO COMIENZA HASTA QUE COMIENCE LA OTRA'),(20,'NO COMIENZA HASTA QUE LA OTRA TERMINE'),(21,'NO FINALIZA HASTA A FINALIZA OTRA'),(22,'NO FINALIZA HASTA QUE COMIENCE LA OTRA'),(26,'No, there are any'),(25,'No, there are not no people'),(3,'NS/NC'),(15,'NUNCA'),(39,'phone'),(40,'phoned'),(41,'phones'),(42,'phoning'),(65,'PHP'),(63,'PHYTON'),(70,'PROLOG'),(51,'REGULAR'),(62,'RUBY'),(73,'SEMANAS'),(1,'SI'),(17,'SIEMPRE'),(46,'SMALLTALK'),(59,'SOLARIS'),(28,'To come'),(57,'UBUNTU'),(32,'was'),(33,'were'),(35,'Where did you find that money'),(36,'Where did you find those keys?'),(38,'Where did you found those tickets?'),(37,'Where were you found them?'),(30,'will come'),(47,'WINDOWS 7'),(55,'WINDOWS NT'),(56,'WINDOWS XP'),(24,'Yes, there are any'),(27,'Yes, there are some');
/*!40000 ALTER TABLE `opcion evaluada` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `opciones`
--

DROP TABLE IF EXISTS `opciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `opciones` (
  `idopciones` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) NOT NULL,
  PRIMARY KEY (`idopciones`),
  UNIQUE KEY `idopciones_UNIQUE` (`idopciones`),
  UNIQUE KEY `nombre_UNIQUE` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=75 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `opciones`
--

LOCK TABLES `opciones` WRITE;
/*!40000 ALTER TABLE `opciones` DISABLE KEYS */;
INSERT INTO `opciones` VALUES (13,'1'),(22,'10'),(14,'2'),(15,'3'),(16,'4'),(17,'5'),(18,'6'),(19,'7'),(20,'8'),(21,'9'),(12,'A VECES'),(28,'ANDROID'),(49,'AÑOS'),(66,'are'),(6,'BUENO'),(35,'C'),(34,'C #'),(33,'C ++'),(61,'come '),(9,'DEPENDE'),(46,'DIAS'),(63,'did'),(44,'DR SCHEME'),(8,'EXCELENTE'),(42,'F#'),(38,'FORTRAN'),(41,'HTML'),(32,'JAVA'),(43,'JAVA SCRIPT'),(29,'LINUX'),(26,'MAC OS'),(4,'MALO'),(51,'MAS'),(47,'MESES'),(31,'MS - DOS'),(7,'MUY BUENO'),(50,'NINGUNA ANTERIORES'),(2,'NO'),(55,'NO COMIENZA HASTA QUE COMIENCE LA OTRA'),(52,'NO COMIENZA HASTA QUE LA OTRA TERMINE'),(53,'NO FINALIZA HASTA A FINALIZA OTRA'),(54,'NO FINALIZA HASTA QUE COMIENCE LA OTRA'),(58,'No, there are any'),(57,'No, there are not no people'),(3,'NS/NC'),(10,'NUNCA'),(71,'phone'),(72,'phoned'),(73,'phones'),(74,'phoning'),(40,'PHP'),(37,'PHYTON'),(45,'PROLOG'),(5,'REGULAR'),(36,'RUBY'),(48,'SEMANAS'),(1,'SI'),(11,'SIEMPRE'),(39,'SMALLTALK'),(30,'SOLARIS'),(60,'To come'),(27,'UBUNTU'),(64,'was'),(65,'were'),(67,'Where did you find that money'),(68,'Where did you find those keys?'),(70,'Where did you found those tickets?'),(69,'Where were you found them?'),(62,'will come'),(24,'WINDOWS 7'),(23,'WINDOWS NT'),(25,'WINDOWS XP'),(56,'Yes, there are any'),(59,'Yes, there are some');
/*!40000 ALTER TABLE `opciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pregunta`
--

DROP TABLE IF EXISTS `pregunta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pregunta` (
  `codigo` varchar(20) NOT NULL,
  `nombre` varchar(20) NOT NULL,
  `pregunta` varchar(255) NOT NULL,
  `Factor_codigo` varchar(20) NOT NULL,
  `Opcion_de_respuesta` varchar(20) NOT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  `eliminado` tinyint(1) DEFAULT NULL,
  `fecha y hora` datetime DEFAULT NULL,
  `Consultor_nroEmpleado` int(11) DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `codigo_UNIQUE` (`codigo`),
  KEY `fk_Pregunta_Opcion_de_Respuesta` (`Opcion_de_respuesta`),
  KEY `fk_Pregunta_Factor1` (`Factor_codigo`),
  KEY `fk_Pregunta_Consultor1` (`Consultor_nroEmpleado`),
  CONSTRAINT `fk_Pregunta_Consultor1` FOREIGN KEY (`Consultor_nroEmpleado`) REFERENCES `consultor` (`nroEmpleado`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Pregunta_Factor1` FOREIGN KEY (`Factor_codigo`) REFERENCES `factor` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_Pregunta_Opcion_de_Respuesta` FOREIGN KEY (`Opcion_de_respuesta`) REFERENCES `opcion de respuesta` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pregunta`
--

LOCK TABLES `pregunta` WRITE;
/*!40000 ALTER TABLE `pregunta` DISABLE KEYS */;
INSERT INTO `pregunta` VALUES ('PR00','PREGUNTA 1','¿La descompoción de estructuras de trabajo (WBS) forma parte de la definicion del alcance?','F01','OR200',NULL,NULL,NULL,NULL),('PR01','PREGUNTA 2','¿Cuando se define un alcance, debe definirse una linea base de los requerimientos?','F01','OR200',NULL,NULL,NULL,NULL),('PR03','PREGUNTA 1','¿Cuantos trabajos a tenido anteriormente?','F05','OR218',NULL,NULL,NULL,NULL),('PR04','PREGUNTA 2','¿A tenido roces con sus superiores?','F05','OR201',NULL,NULL,NULL,NULL),('PR05','PREGUNTA 3','¿Posee antecedentes penales?','F05','OR201',NULL,NULL,NULL,NULL),('PR06','PREGUNTA 1','¿Pienza que coordinar el esfuerzo de los grupos de trabajo para proporcionar unidad de acción en la consecución de objetivos comunes es una buena practica?','F07','OR200',NULL,NULL,NULL,NULL),('PR07','PREGUNTA 2','¿Implementaria que personal al Servicio del Organismo Social trabaje para lograr los Objetivos Organizacion?','F07','OR203',NULL,NULL,NULL,NULL),('PR08','PREGUNTA 3','¿La empresa debe dar oportunidades de crecimiento a todos sus empleados?','F07','OR200',NULL,NULL,NULL,NULL),('PR09','PREGUNTA 4','GENERICA PARA EL FACTOR PRODUCTIVIDAD DEL PERSONAL','F07','OR205',NULL,NULL,NULL,NULL),('PR10','PREGUNTA 5','GENERICA PARA EL FACTOR PRODUCTIVIDAD DEL PERSONAL','F07','OR204',NULL,NULL,NULL,NULL),('PR11','PREGUNTA 3','GENERICA PARA EL FACTOR GESTION DE TIEMPO','F00','OR207',NULL,NULL,NULL,NULL),('PR12','PREGUNTA 4','¿Aceleraria los tiempos de entrega de un proyecto cuando se cumplen con exito cada etapa?','F00','OR201',NULL,NULL,NULL,NULL),('PR19','PREGUNTA 3','GENERICA PARA EL FACTOR GESTION DEL ALCANCE','F01','OR207',NULL,NULL,NULL,NULL),('PR20','PREGUNTA 1','En el cronograma de un proyecto, ¿Que significa que una actividad sea del tipo \"fin a comienzo\"?','F00','OR219',NULL,NULL,NULL,NULL),('PR21','PREGUNTA 2','¿La metodología de \"Valor Ganado\" permite predecir cuánto dinero se gastará en un proyecto según los avances que el mismo tenga a la fecha?','F00','OR200',NULL,NULL,NULL,NULL),('PR22','PREGUNTA 4','GENERICA PARA EL FACTOR ESTABILIDAD LABORAL','F05','OR206',NULL,NULL,NULL,NULL),('PR23','PREGUNTA 5','GENERICA PARA EL FACTOR ESTABILIDAD LABORAL','F05','OR205',NULL,NULL,NULL,NULL),('PR24','PREGUNTA 1','En la etapa de diseño ¿Cuando realizaria un diagrama de estados?','F10','OR203',NULL,NULL,NULL,NULL),('PR25','PREGUNTA 2','En una propuesta de sistema ¿Se debe incluir el resumen ejecutivo?','F10','OR200',NULL,NULL,NULL,NULL),('PR26','PREGUNTA 3','¿Una prueba se consedera exitosa si no encuentra ningún error en el sistema?','F10','OR201',NULL,NULL,NULL,NULL),('PR27','PREGUNTA 4','La ELICITACION DE REQUERIMIENTOS ¿Tiene por objetivo eliminar las ambiguedades del lenguaje coloquial? ','F10','OR201',NULL,NULL,NULL,NULL),('PR28','PREGUNTA 5','¿Las salidas del sistema se consideran exitosas si llegan en tiempo y forma a donde estan destinada?','F10','OR207',NULL,NULL,NULL,NULL),('PR29','PREGUNTA 6','En una PRUEBA A CAJA BLANCA ¿SOLO se conocen las especificaciones funcionales de las clases?','F10','OR200',NULL,NULL,NULL,NULL),('PR30','PREGUNTA 1','El modelo de diseño, ¿Es particular y dependiente de las herramientas que se van a utilizar en el desarrollo del programa?','F02','OR207',NULL,NULL,NULL,NULL),('PR31','PREGUNTA 2','En el modelo de diseño, ¿Se contemplan interacciones con el usuario?','F02','OR201',NULL,NULL,NULL,NULL),('PR32','PREGUNTA 3','¿El diseño de salidas consedera los factores de alcance, tiempo, costo y calidad?','F02','OR200',NULL,NULL,NULL,NULL),('PR33','PREGUNTA 4','¿El modelo de analisis es considerado como una abstraccion del sistema dado que solo brinda un bosquejo del sistema?','F02','OR200',NULL,NULL,NULL,NULL),('PR34','PREGUNTA 5','A su criterio ¿Cual seria la cantidad MINIMA de CAPAS en un proyecto que cuenta con interacciones con el usuario y transacciones de con una base de datos?','F02','OR218',NULL,NULL,NULL,NULL),('PR35','PREGUNTA 1','¿En el modelo de despliege, los procesadores son elementos con capacidad de procesamiento y estan representados por cubo?','F09','OR200',NULL,NULL,NULL,NULL),('PR36','PREGUNTA 2','En el modelo de clases, ¿Las asociaciones establecen roles y navegabilidades?','F09','OR201',NULL,NULL,NULL,NULL),('PR37','PREGUNTA 3','En el modelo de clases, ¿Las clases de diseño son una abstraccion del sistema?','F09','OR201',NULL,NULL,NULL,NULL),('PR38','PREGUNTA 4','En el modelo se ciclo de vida del software, ¿Es correcta la siguiente secuencia? ANALISIS REQUERIMIENTOS - DISEÑO - DESARROLLO - IMPLEMENTACION - MANTENIMIENTO','F09','OR200',NULL,NULL,NULL,NULL),('PR39','PREGUNTA 5','En el modelo de casos de uso  ¿Se muestran los requerimientos funcionales del sistema?','F09','OR200',NULL,NULL,NULL,NULL),('PR40','PREGUNTA 1','Are here any people in the bank?','F03','OR220',NULL,NULL,NULL,NULL),('PR41','PREGUNTA 2','Henry _______ next week.','F03','OR221',NULL,NULL,NULL,NULL),('PR42','PREGUNTA 3','What ___ you do last week? ','F03','OR222',NULL,NULL,NULL,NULL),('PR43','PREGUNTA 4','I found them in the street','F03','OR223',NULL,NULL,NULL,NULL),('PR44','PREGUNTA 5','What was she doing when he _____?','F03','OR224',NULL,NULL,NULL,NULL),('PR45','PREGUNTA 6','Si tuviera que puntuar su conocimiento de INGLES, ¿Cuanto te pondrias?','F03','OR205',NULL,NULL,NULL,NULL),('PR46','PREGUNTA 1','GENERICA PARA EL FACTOR CONOCIMIENTOS DE INGLES AVANZADOS','F04','OR200',NULL,NULL,NULL,NULL),('PR47','PREGUNTA 1','¿El uso de comentarios en el codigo lo considera como una practica de programación?','F12','OR202',NULL,NULL,NULL,NULL),('PR48','PREGUNTA 2','¿Cual de los siguientes lenguajes de programacion soporta esquemas de herencia multiple?','F13','OR214',NULL,NULL,NULL,NULL),('PR49','PREGUNTA 3','¿Cual de los siguiente lenguajes fue el primero en implementar la teoria de objetos?','F13','OR211',NULL,NULL,NULL,NULL),('PR50','PREGUNTA 4','¿Una clase puede tener como nombre un número o su nombre empezar por un número?','F13','OR200',NULL,NULL,NULL,NULL),('PR51','PREGUNTA 5','¿Este código compila? private class MiClase1 { }','F13','OR200',NULL,NULL,NULL,NULL),('PR52','PREGUNTA 1','¿Se puede realizar la siguente declaracion de metodos? int metodo1(char a); int metodo1(char a, char b);','F13','OR200',NULL,NULL,NULL,NULL),('PR53','PREGUNTA 2','PREGUNTA GENERICA PARA ESTE FACTOR','F12','OR204',NULL,NULL,NULL,NULL),('PR54','PREGUNTA 1','PREGUNTA GENERICA PARA ESTE FACTOR','F11','OR209',NULL,NULL,NULL,NULL),('PR56','PREGUNTA 2','¿Un pseudocodigo representa la solucion aun algoritmo un problema de logica una situacion cotidiana un software de programar?','F15','OR200',NULL,NULL,NULL,NULL),('PR57','PREGUNTA 3','¿Un función FORK() crea un nuevo proceso hijo del proceso actual con la misma imagen que el proceso actual?','F15','OR201',NULL,NULL,NULL,NULL),('PR58','PREGUNTA 4','¿En que sistema operativo está la función CreateProcess?','F15','OR216',NULL,NULL,NULL,NULL),('PR59','PREGUNTA 5','¿Eclipse se conoce como un IDE de que plataforma de programación?','F15','OR214',NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `pregunta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pregunta evaluada`
--

DROP TABLE IF EXISTS `pregunta evaluada`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pregunta evaluada` (
  `idPregunta Evaluada` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(20) NOT NULL,
  `nombre` varchar(20) NOT NULL,
  `pregunta` varchar(255) NOT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  `eliminado` tinyint(1) DEFAULT NULL,
  `Factor Evaluado_idFactor Evaluado` int(11) NOT NULL,
  `Opcion de Respuesta Evaluada_idOpcion de Respuesta Evaluada` int(11) NOT NULL,
  PRIMARY KEY (`idPregunta Evaluada`),
  KEY `fk_Pregunta Evaluada_Factor Evaluado1` (`Factor Evaluado_idFactor Evaluado`),
  KEY `fk_Pregunta Evaluada_Opcion de Respuesta Evaluada1` (`Opcion de Respuesta Evaluada_idOpcion de Respuesta Evaluada`),
  CONSTRAINT `fk_Pregunta Evaluada_Factor Evaluado1` FOREIGN KEY (`Factor Evaluado_idFactor Evaluado`) REFERENCES `factor evaluado` (`idFactor Evaluado`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Pregunta Evaluada_Opcion de Respuesta Evaluada1` FOREIGN KEY (`Opcion de Respuesta Evaluada_idOpcion de Respuesta Evaluada`) REFERENCES `opcion de respuesta evaluada` (`idOpcion de Respuesta Evaluada`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pregunta evaluada`
--

LOCK TABLES `pregunta evaluada` WRITE;
/*!40000 ALTER TABLE `pregunta evaluada` DISABLE KEYS */;
/*!40000 ALTER TABLE `pregunta evaluada` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pregunta evaluada_opcion evaluada`
--

DROP TABLE IF EXISTS `pregunta evaluada_opcion evaluada`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pregunta evaluada_opcion evaluada` (
  `Opcion Evaluada_idOpcion` int(11) NOT NULL,
  `Pregunta Evaluada_idPregunta Evaluada` int(11) NOT NULL,
  `ponderacion` int(11) NOT NULL,
  PRIMARY KEY (`Opcion Evaluada_idOpcion`,`Pregunta Evaluada_idPregunta Evaluada`),
  KEY `fk_Opcion Evaluada_has_Pregunta Evaluada_Pregunta Evaluada1` (`Pregunta Evaluada_idPregunta Evaluada`),
  KEY `fk_Opcion Evaluada_has_Pregunta Evaluada_Opcion Evaluada1` (`Opcion Evaluada_idOpcion`),
  CONSTRAINT `fk_Opcion Evaluada_has_Pregunta Evaluada_Opcion Evaluada1` FOREIGN KEY (`Opcion Evaluada_idOpcion`) REFERENCES `opcion evaluada` (`idOpcion`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Opcion Evaluada_has_Pregunta Evaluada_Pregunta Evaluada1` FOREIGN KEY (`Pregunta Evaluada_idPregunta Evaluada`) REFERENCES `pregunta evaluada` (`idPregunta Evaluada`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pregunta evaluada_opcion evaluada`
--

LOCK TABLES `pregunta evaluada_opcion evaluada` WRITE;
/*!40000 ALTER TABLE `pregunta evaluada_opcion evaluada` DISABLE KEYS */;
/*!40000 ALTER TABLE `pregunta evaluada_opcion evaluada` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pregunta_opciones`
--

DROP TABLE IF EXISTS `pregunta_opciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pregunta_opciones` (
  `Opciones_idopciones` int(11) NOT NULL,
  `Pregunta_codigo` varchar(20) NOT NULL,
  `ponderacion` int(11) NOT NULL,
  PRIMARY KEY (`Opciones_idopciones`,`Pregunta_codigo`),
  KEY `fk_Opciones_has_Pregunta_Pregunta1` (`Pregunta_codigo`),
  KEY `fk_Opciones_has_Pregunta_Opciones1` (`Opciones_idopciones`),
  CONSTRAINT `fk_Opciones_has_Pregunta_Opciones1` FOREIGN KEY (`Opciones_idopciones`) REFERENCES `opciones` (`idopciones`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Opciones_has_Pregunta_Pregunta1` FOREIGN KEY (`Pregunta_codigo`) REFERENCES `pregunta` (`codigo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pregunta_opciones`
--

LOCK TABLES `pregunta_opciones` WRITE;
/*!40000 ALTER TABLE `pregunta_opciones` DISABLE KEYS */;
INSERT INTO `pregunta_opciones` VALUES (1,'PR00',7),(1,'PR01',8),(1,'PR04',10),(1,'PR05',0),(1,'PR06',8),(1,'PR08',0),(1,'PR12',10),(1,'PR21',6),(1,'PR25',10),(1,'PR26',0),(1,'PR27',10),(1,'PR29',0),(1,'PR31',10),(1,'PR32',8),(1,'PR33',9),(1,'PR35',10),(1,'PR36',10),(1,'PR37',0),(1,'PR38',9),(1,'PR39',10),(1,'PR46',5),(1,'PR47',10),(1,'PR50',0),(1,'PR51',0),(1,'PR52',8),(1,'PR56',8),(1,'PR57',10),(2,'PR00',0),(2,'PR01',0),(2,'PR04',0),(2,'PR05',10),(2,'PR06',0),(2,'PR08',8),(2,'PR12',0),(2,'PR21',0),(2,'PR25',0),(2,'PR26',10),(2,'PR27',0),(2,'PR29',8),(2,'PR31',0),(2,'PR32',0),(2,'PR33',0),(2,'PR35',0),(2,'PR36',0),(2,'PR37',10),(2,'PR38',0),(2,'PR39',0),(2,'PR46',3),(2,'PR47',0),(2,'PR50',8),(2,'PR51',9),(2,'PR52',0),(2,'PR56',0),(2,'PR57',0),(3,'PR00',3),(3,'PR01',2),(3,'PR06',2),(3,'PR08',2),(3,'PR21',4),(3,'PR25',0),(3,'PR29',2),(3,'PR32',2),(3,'PR33',1),(3,'PR35',0),(3,'PR38',1),(3,'PR39',0),(3,'PR46',2),(3,'PR47',0),(3,'PR50',2),(3,'PR51',1),(3,'PR52',2),(3,'PR56',2),(4,'PR22',0),(5,'PR22',0),(6,'PR10',3),(6,'PR22',0),(6,'PR53',5),(7,'PR10',7),(7,'PR22',5),(7,'PR53',5),(8,'PR22',2),(9,'PR07',5),(9,'PR11',3),(9,'PR19',2),(9,'PR24',7),(9,'PR28',1),(9,'PR30',2),(10,'PR07',0),(10,'PR11',0),(10,'PR19',2),(10,'PR24',3),(10,'PR28',1),(10,'PR30',0),(11,'PR07',3),(11,'PR11',0),(11,'PR19',3),(11,'PR24',0),(11,'PR28',8),(11,'PR30',7),(12,'PR07',2),(12,'PR11',3),(12,'PR19',3),(12,'PR24',0),(12,'PR28',0),(12,'PR30',1),(13,'PR03',2),(13,'PR09',1),(13,'PR23',0),(13,'PR34',2),(13,'PR45',0),(14,'PR03',3),(14,'PR09',1),(14,'PR23',0),(14,'PR34',0),(14,'PR45',0),(15,'PR03',3),(15,'PR09',1),(15,'PR23',0),(15,'PR34',6),(15,'PR45',0),(16,'PR03',1),(16,'PR09',1),(16,'PR23',0),(16,'PR34',0),(16,'PR45',1),(17,'PR09',1),(17,'PR23',0),(17,'PR45',1),(18,'PR09',1),(18,'PR23',2),(18,'PR45',2),(19,'PR09',1),(19,'PR23',2),(19,'PR45',2),(20,'PR09',1),(20,'PR23',2),(20,'PR45',2),(21,'PR09',1),(21,'PR23',2),(21,'PR45',2),(22,'PR09',1),(22,'PR23',2),(22,'PR45',0),(24,'PR54',2),(24,'PR58',10),(26,'PR54',2),(26,'PR58',0),(27,'PR54',2),(28,'PR54',1),(29,'PR54',1),(29,'PR58',0),(30,'PR54',2),(32,'PR48',0),(32,'PR49',0),(32,'PR59',10),(33,'PR48',0),(33,'PR49',0),(33,'PR59',0),(34,'PR48',0),(34,'PR49',0),(34,'PR59',0),(39,'PR48',0),(39,'PR49',10),(39,'PR59',0),(50,'PR11',4),(50,'PR19',0),(50,'PR22',3),(50,'PR28',0),(50,'PR30',0),(50,'PR48',10),(50,'PR58',0),(50,'PR59',0),(51,'PR03',1),(51,'PR34',2),(52,'PR20',10),(53,'PR20',0),(54,'PR20',0),(55,'PR20',0),(56,'PR40',0),(57,'PR40',0),(58,'PR40',0),(59,'PR40',10),(60,'PR41',0),(61,'PR41',0),(62,'PR41',10),(63,'PR42',10),(64,'PR42',0),(65,'PR42',0),(66,'PR42',0),(67,'PR43',0),(68,'PR43',10),(69,'PR43',0),(70,'PR43',0),(71,'PR44',10),(72,'PR44',0),(73,'PR44',0),(74,'PR44',0);
/*!40000 ALTER TABLE `pregunta_opciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `puesto`
--

DROP TABLE IF EXISTS `puesto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `puesto` (
  `codigo` varchar(20) NOT NULL COMMENT ' ',
  `nombre` varchar(45) NOT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  `eliminado` tinyint(1) DEFAULT NULL,
  `fecha y hora` datetime DEFAULT NULL,
  `Consultor_nroEmpleado` int(11) DEFAULT NULL,
  `empresa` varchar(45) NOT NULL,
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `codigo_UNIQUE` (`codigo`),
  KEY `fk_Puesto_Consultor1` (`Consultor_nroEmpleado`),
  CONSTRAINT `fk_Puesto_Consultor1` FOREIGN KEY (`Consultor_nroEmpleado`) REFERENCES `consultor` (`nroEmpleado`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `puesto`
--

LOCK TABLES `puesto` WRITE;
/*!40000 ALTER TABLE `puesto` DISABLE KEYS */;
INSERT INTO `puesto` VALUES ('P01','PROGRAMADOR JAVA','CONOCIMIENTOS GRAL PROGRAMACION, LENGUA EXTRANJERA',NULL,NULL,NULL,'MILENIO'),('P02','DISEÑADOR','CONOC. GRAL PROGRAMACION, DISEÑO DE SISTEMAS, LENGUA EXTRANJERA',NULL,NULL,NULL,'ISICOP'),('P03','ADMINISTRADOR RR HH','ADMINISTRACION RECURSOS HUMANOS, GESTION DE PROYECTOS',NULL,NULL,NULL,'SIMS');
/*!40000 ALTER TABLE `puesto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `puesto evaluado`
--

DROP TABLE IF EXISTS `puesto evaluado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `puesto evaluado` (
  `idPuesto Evaluado` int(11) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(20) NOT NULL,
  `nombre` varchar(20) NOT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  `eliminado` tinyint(1) DEFAULT NULL,
  `empresa` varchar(20) NOT NULL,
  PRIMARY KEY (`idPuesto Evaluado`),
  UNIQUE KEY `idPuesto Evaluado_UNIQUE` (`idPuesto Evaluado`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `puesto evaluado`
--

LOCK TABLES `puesto evaluado` WRITE;
/*!40000 ALTER TABLE `puesto evaluado` DISABLE KEYS */;
/*!40000 ALTER TABLE `puesto evaluado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `puesto evaluado_competencia evaluada`
--

DROP TABLE IF EXISTS `puesto evaluado_competencia evaluada`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `puesto evaluado_competencia evaluada` (
  `Puesto Evaluado_idPuesto Evaluado` int(11) NOT NULL,
  `Competencia Evaluada_idCompetencia Evaluada` int(11) NOT NULL,
  `ponderacion` int(11) NOT NULL,
  PRIMARY KEY (`Puesto Evaluado_idPuesto Evaluado`,`Competencia Evaluada_idCompetencia Evaluada`),
  KEY `fk_Puesto Evaluado_has_Competencia Evaluada_Competencia Evalu1` (`Competencia Evaluada_idCompetencia Evaluada`),
  KEY `fk_Puesto Evaluado_has_Competencia Evaluada_Puesto Evaluado1` (`Puesto Evaluado_idPuesto Evaluado`),
  CONSTRAINT `fk_Puesto Evaluado_has_Competencia Evaluada_Competencia Evalu1` FOREIGN KEY (`Competencia Evaluada_idCompetencia Evaluada`) REFERENCES `competencia evaluada` (`idCompetencia Evaluada`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Puesto Evaluado_has_Competencia Evaluada_Puesto Evaluado1` FOREIGN KEY (`Puesto Evaluado_idPuesto Evaluado`) REFERENCES `puesto evaluado` (`idPuesto Evaluado`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `puesto evaluado_competencia evaluada`
--

LOCK TABLES `puesto evaluado_competencia evaluada` WRITE;
/*!40000 ALTER TABLE `puesto evaluado_competencia evaluada` DISABLE KEYS */;
/*!40000 ALTER TABLE `puesto evaluado_competencia evaluada` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `puesto_competencia`
--

DROP TABLE IF EXISTS `puesto_competencia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `puesto_competencia` (
  `Puesto_codigo` varchar(20) NOT NULL,
  `Competencia_codigo` varchar(20) NOT NULL,
  `ponderacion` int(11) NOT NULL,
  PRIMARY KEY (`Puesto_codigo`,`Competencia_codigo`),
  KEY `fk_Puesto_has_Competencia_Competencia1` (`Competencia_codigo`),
  KEY `fk_Puesto_has_Competencia_Puesto` (`Puesto_codigo`),
  CONSTRAINT `fk_Puesto_has_Competencia_Competencia1` FOREIGN KEY (`Competencia_codigo`) REFERENCES `competencia` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_Puesto_has_Competencia_Puesto` FOREIGN KEY (`Puesto_codigo`) REFERENCES `puesto` (`codigo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `puesto_competencia`
--

LOCK TABLES `puesto_competencia` WRITE;
/*!40000 ALTER TABLE `puesto_competencia` DISABLE KEYS */;
INSERT INTO `puesto_competencia` VALUES ('P01','C03',5),('P01','C04',3),('P02','C02',6),('P02','C03',4),('P02','C04',3),('P03','C00',3),('P03','C01',4);
/*!40000 ALTER TABLE `puesto_competencia` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2012-02-23 15:46:12
