# Tetris Game

## Description
Ce projet est une implémentation du jeu de Tetris en utilisant **C#** et **Windows Forms**. Il propose une interface graphique pour l'interaction avec les utilisateurs, comprenant un menu principal, un formulaire de jeu, et un formulaire d'options pour configurer la difficulté du jeu. Le score du joueur est affiché en temps réel et le score le plus élevé est sauvegardé dans un fichier texte.

##Groupe 
- Herison
- Awa 
 **Awa** a travaillé sur la création du menu principal et des options de jeu, et **Herison** il a fait le développement du cœur du jeu, incluant la logique de jeu, la gestion des pièces et des scores.

## Fonctionnalités

### Menu Principal(Awa)
- Un menu qui permet de démarrer une nouvelle partie, de régler la difficulté et de quitter le jeu.
- Le formulaire du menu principal.

### Options de jeu
- Le joueur peut choisir entre différentes difficultés : **Facile**, **Moyen**, **Difficile**.
- Les options incluent également la possibilité de modifier la vitesse de chute des pièces en fonction de la difficulté choisie.
- Developpement de la fenêtre des options.

### Jeu
- **Herison** a implémenté la logique du jeu de Tetris :
  - Affichage des pièces de Tetris qui tombent dans un espace de jeu.
  - Rotation des pièces et déplacement des pièces à gauche, à droite et vers le bas.
  - Suppression des lignes complètes lorsqu'elles sont remplies de blocs.
  - Mise à jour du score en temps réel pendant la partie.
  - Le jeu continue jusqu'à ce que l'espace de jeu soit rempli.

### Sauvegarde du score
- Le score du joueur est sauvegardé automatiquement dans un fichier texte à la fin de chaque session de jeu.
- Le **Top Score** est affiché dans l'interface du jeu.

### Interface graphique
- Une interface simple et intuitive qui affiche :
  - Le jeu en cours avec les pièces qui tombent.
  - Le score actuel et le meilleur score.
  - Des contrôles visuels pour commencer le jeu, ajuster la difficulté et quitter.

## Technologies utilisées

- **C#** avec **Windows Forms** pour l'interface graphique.
- **.NET Framework** pour le développement de l'application.
- Fichiers texte pour la sauvegarde des scores.

## Lien du depot 
https://github.com/dolobe/Tetris-Project.git

NB : Le jeu est dans le TetrisGameTest

