-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  mar. 10 déc. 2019 à 14:29
-- Version du serveur :  5.7.26
-- Version de PHP :  7.3.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `projetb2csharp`
--

-- --------------------------------------------------------

--
-- Structure de la table `commune`
--

DROP TABLE IF EXISTS `commune`;
CREATE TABLE IF NOT EXISTS `commune` (
  `idCommune` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(45) NOT NULL,
  `idDepartement` int(11) NOT NULL,
  PRIMARY KEY (`idCommune`),
  KEY `fk_Commune_Departement1_idx` (`idDepartement`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `commune`
--

INSERT INTO `commune` (`idCommune`, `nom`, `idDepartement`) VALUES
(1, 'MauvaisNumeroCommune', 1),
(2, 'Nom', 1),
(3, 'fez', 1),
(4, 'fez', 1),
(5, 'fez', 1),
(6, 'Nom', 1),
(7, 'ytvd', 1),
(8, 'ytvd', 1),
(9, 'yes', 1),
(10, 'yes', 1);

-- --------------------------------------------------------

--
-- Structure de la table `departement`
--

DROP TABLE IF EXISTS `departement`;
CREATE TABLE IF NOT EXISTS `departement` (
  `idDepartement` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(45) NOT NULL,
  `numero` int(11) NOT NULL,
  PRIMARY KEY (`idDepartement`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `departement`
--

INSERT INTO `departement` (`idDepartement`, `nom`, `numero`) VALUES
(1, 'MauvaisNumeroDepartement', 0),
(2, 'Languedoc', 0),
(3, 'Nom', 0);

-- --------------------------------------------------------

--
-- Structure de la table `equipe`
--

DROP TABLE IF EXISTS `equipe`;
CREATE TABLE IF NOT EXISTS `equipe` (
  `idEquipe` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(45) NOT NULL,
  `nombreMembres` int(11) NOT NULL,
  PRIMARY KEY (`idEquipe`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `equipe`
--

INSERT INTO `equipe` (`idEquipe`, `nom`, `nombreMembres`) VALUES
(1, 'MauvaisNumeroEquipe', 0),
(2, 'Nom', 0),
(3, 'Nom', 45);

-- --------------------------------------------------------

--
-- Structure de la table `espece`
--

DROP TABLE IF EXISTS `espece`;
CREATE TABLE IF NOT EXISTS `espece` (
  `idEspece` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) NOT NULL,
  PRIMARY KEY (`idEspece`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `espece`
--

INSERT INTO `espece` (`idEspece`, `nom`) VALUES
(1, 'MauvaisNumeroEspece');

-- --------------------------------------------------------

--
-- Structure de la table `espece_has_plage`
--

DROP TABLE IF EXISTS `espece_has_plage`;
CREATE TABLE IF NOT EXISTS `espece_has_plage` (
  `Espece_idEspece` int(11) NOT NULL,
  `Plage_idPlage` int(11) NOT NULL,
  `densite` float NOT NULL,
  `populationTotale` float NOT NULL,
  PRIMARY KEY (`Espece_idEspece`,`Plage_idPlage`),
  KEY `fk_Espece_has_Plage_Plage1_idx` (`Plage_idPlage`),
  KEY `fk_Espece_has_Plage_Espece1_idx` (`Espece_idEspece`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `espece_has_zoneprelevement`
--

DROP TABLE IF EXISTS `espece_has_zoneprelevement`;
CREATE TABLE IF NOT EXISTS `espece_has_zoneprelevement` (
  `Espece_idEspece` int(11) NOT NULL,
  `ZonePrelevement_idZonePrelevement` int(11) NOT NULL,
  `nombreEspeceZone` int(11) NOT NULL,
  PRIMARY KEY (`Espece_idEspece`,`ZonePrelevement_idZonePrelevement`),
  KEY `fk_Espece_has_ZonePrelevement_ZonePrelevement1_idx` (`ZonePrelevement_idZonePrelevement`),
  KEY `fk_Espece_has_ZonePrelevement_Espece1_idx` (`Espece_idEspece`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `etude`
--

DROP TABLE IF EXISTS `etude`;
CREATE TABLE IF NOT EXISTS `etude` (
  `idEtude` int(11) NOT NULL AUTO_INCREMENT,
  `date` datetime NOT NULL,
  `titre` varchar(45) NOT NULL,
  `nbTotalEspeceRencontree` int(11) NOT NULL,
  `idEquipe` int(11) NOT NULL,
  PRIMARY KEY (`idEtude`),
  KEY `fk_Etude_Equipe1_idx` (`idEquipe`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `etude`
--

INSERT INTO `etude` (`idEtude`, `date`, `titre`, `nbTotalEspeceRencontree`, `idEquipe`) VALUES
(1, '1970-01-01 00:00:00', 'MauvaisNumeroEtude', 0, 1);

-- --------------------------------------------------------

--
-- Structure de la table `etude_has_espece`
--

DROP TABLE IF EXISTS `etude_has_espece`;
CREATE TABLE IF NOT EXISTS `etude_has_espece` (
  `Etude_idEtude` int(11) NOT NULL,
  `Espece_idEspece` int(11) NOT NULL,
  `densiteTotaleEspece` float NOT NULL,
  PRIMARY KEY (`Etude_idEtude`,`Espece_idEspece`),
  KEY `fk_Etude_has_Espece_Espece1_idx` (`Espece_idEspece`),
  KEY `fk_Etude_has_Espece_Etude1_idx` (`Etude_idEtude`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `etude_has_plage`
--

DROP TABLE IF EXISTS `etude_has_plage`;
CREATE TABLE IF NOT EXISTS `etude_has_plage` (
  `Etude_idEtude` int(11) NOT NULL,
  `Plage_idPlage` int(11) NOT NULL,
  `zoneprelevement_idZonePrelevement` int(11) NOT NULL,
  `name_concatenation` varchar(45) NOT NULL,
  PRIMARY KEY (`Etude_idEtude`,`Plage_idPlage`,`zoneprelevement_idZonePrelevement`),
  KEY `fk_Etude_has_Plage_Plage1_idx` (`Plage_idPlage`),
  KEY `fk_Etude_has_Plage_Etude1_idx` (`Etude_idEtude`),
  KEY `fk_etude_has_plage_zoneprelevement1_idx` (`zoneprelevement_idZonePrelevement`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `plage`
--

DROP TABLE IF EXISTS `plage`;
CREATE TABLE IF NOT EXISTS `plage` (
  `idPlage` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(45) NOT NULL,
  `idCommune` int(11) NOT NULL,
  `nbEspecesDifferentes` int(11) NOT NULL,
  `surface` float NOT NULL,
  PRIMARY KEY (`idPlage`),
  KEY `fk_Plage_Commune1_idx` (`idCommune`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `plage`
--

INSERT INTO `plage` (`idPlage`, `nom`, `idCommune`, `nbEspecesDifferentes`, `surface`) VALUES
(1, 'MauvaisNumeroPlage', 1, 0, 0),
(2, 'Nom', 1, 50, 0),
(3, 'Nom', 1, 0, 0);

-- --------------------------------------------------------

--
-- Structure de la table `utilisateur`
--

DROP TABLE IF EXISTS `utilisateur`;
CREATE TABLE IF NOT EXISTS `utilisateur` (
  `idUtilisateur` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(45) NOT NULL,
  `prenom` varchar(45) NOT NULL,
  `isAdmin` tinyint(1) NOT NULL,
  `password` varchar(150) NOT NULL,
  `login` varchar(45) NOT NULL,
  PRIMARY KEY (`idUtilisateur`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `utilisateur`
--

INSERT INTO `utilisateur` (`idUtilisateur`, `nom`, `prenom`, `isAdmin`, `password`, `login`) VALUES
(1, 'Bad', 'UserName', 0, '334c4a4c42fdb79d7ebc3e73b517e6f8', 'none'),
(5, 'Kévin', 'GILLET', 1, '6273e197f07ce4a00485a7aa6258dc91', 'Kev'),
(6, 'NOM', 'Prenom', 1, 'd56b699830e77ba53855679cb1d252da', 'password');

-- --------------------------------------------------------

--
-- Structure de la table `utilisateur_has_equipe`
--

DROP TABLE IF EXISTS `utilisateur_has_equipe`;
CREATE TABLE IF NOT EXISTS `utilisateur_has_equipe` (
  `Utilisateur_idUtilisateur` int(11) NOT NULL,
  `Equipe_idEquipe` int(11) NOT NULL,
  PRIMARY KEY (`Utilisateur_idUtilisateur`,`Equipe_idEquipe`),
  KEY `fk_Utilisateur_has_Equipe_Equipe1_idx` (`Equipe_idEquipe`),
  KEY `fk_Utilisateur_has_Equipe_Utilisateur1_idx` (`Utilisateur_idUtilisateur`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `zoneprelevement`
--

DROP TABLE IF EXISTS `zoneprelevement`;
CREATE TABLE IF NOT EXISTS `zoneprelevement` (
  `idZonePrelevement` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(45) NOT NULL,
  `lat1` decimal(9,6) NOT NULL,
  `lat2` decimal(9,6) NOT NULL,
  `lat3` decimal(9,6) NOT NULL,
  `lat4` decimal(9,6) NOT NULL,
  `long1` decimal(9,6) NOT NULL,
  `long2` decimal(9,6) NOT NULL,
  `long3` decimal(9,6) NOT NULL,
  `long4` decimal(9,6) NOT NULL,
  PRIMARY KEY (`idZonePrelevement`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `zoneprelevement`
--

INSERT INTO `zoneprelevement` (`idZonePrelevement`, `nom`, `lat1`, `lat2`, `lat3`, `lat4`, `long1`, `long2`, `long3`, `long4`) VALUES
(1, 'MauvaisNumeroZonePrelevement', '0.000000', '0.000000', '0.000000', '0.000000', '0.000000', '0.000000', '0.000000', '0.000000');

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `commune`
--
ALTER TABLE `commune`
  ADD CONSTRAINT `fk_Commune_Departement1` FOREIGN KEY (`idDepartement`) REFERENCES `departement` (`idDepartement`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Contraintes pour la table `espece_has_plage`
--
ALTER TABLE `espece_has_plage`
  ADD CONSTRAINT `fk_Espece_has_Plage_Espece1` FOREIGN KEY (`Espece_idEspece`) REFERENCES `espece` (`idEspece`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Espece_has_Plage_Plage1` FOREIGN KEY (`Plage_idPlage`) REFERENCES `plage` (`idPlage`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Contraintes pour la table `espece_has_zoneprelevement`
--
ALTER TABLE `espece_has_zoneprelevement`
  ADD CONSTRAINT `fk_Espece_has_ZonePrelevement_Espece1` FOREIGN KEY (`Espece_idEspece`) REFERENCES `espece` (`idEspece`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Espece_has_ZonePrelevement_ZonePrelevement1` FOREIGN KEY (`ZonePrelevement_idZonePrelevement`) REFERENCES `zoneprelevement` (`idZonePrelevement`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Contraintes pour la table `etude`
--
ALTER TABLE `etude`
  ADD CONSTRAINT `fk_Etude_Equipe1` FOREIGN KEY (`idEquipe`) REFERENCES `equipe` (`idEquipe`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Contraintes pour la table `etude_has_espece`
--
ALTER TABLE `etude_has_espece`
  ADD CONSTRAINT `fk_Etude_has_Espece_Espece1` FOREIGN KEY (`Espece_idEspece`) REFERENCES `espece` (`idEspece`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Etude_has_Espece_Etude1` FOREIGN KEY (`Etude_idEtude`) REFERENCES `etude` (`idEtude`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Contraintes pour la table `etude_has_plage`
--
ALTER TABLE `etude_has_plage`
  ADD CONSTRAINT `fk_Etude_has_Plage_Etude1` FOREIGN KEY (`Etude_idEtude`) REFERENCES `etude` (`idEtude`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Etude_has_Plage_Plage1` FOREIGN KEY (`Plage_idPlage`) REFERENCES `plage` (`idPlage`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_etude_has_plage_zoneprelevement1` FOREIGN KEY (`zoneprelevement_idZonePrelevement`) REFERENCES `zoneprelevement` (`idZonePrelevement`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Contraintes pour la table `plage`
--
ALTER TABLE `plage`
  ADD CONSTRAINT `fk_Plage_Commune1` FOREIGN KEY (`idCommune`) REFERENCES `commune` (`idCommune`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Contraintes pour la table `utilisateur_has_equipe`
--
ALTER TABLE `utilisateur_has_equipe`
  ADD CONSTRAINT `fk_Utilisateur_has_Equipe_Equipe1` FOREIGN KEY (`Equipe_idEquipe`) REFERENCES `equipe` (`idEquipe`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Utilisateur_has_Equipe_Utilisateur1` FOREIGN KEY (`Utilisateur_idUtilisateur`) REFERENCES `utilisateur` (`idUtilisateur`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
