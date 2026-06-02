# [Project A]

> Projet Unity 2D/3D développé en équipe de 6 personnes (Développeurs, Game Designers, Artistes).

---

## Sommaire

- [Présentation](#-présentation)
- [Équipe](#-équipe)
- [Stack Technique](#-stack-technique)
- [Workflow Git](#-workflow-git)
- [Architecture du Projet](#-architecture-du-projet)
- [Conventions de Nommage](#-conventions-de-nommage)
- [Règles de Code](#-règles-de-code)
- [Comment Contribuer](#-comment-contribuer)

---

## Présentation

**Genre :** [Action / Plateformer / Roguelite / etc.]
**Plateforme :** PC (Windows)
**Moteur :** Unity 2D (URP)
**Pitch :** _[Décrire le concept du jeu en quelques lignes]_

---

## Équipe

| Rôle | Nom | Branche dédiée |
|------|-----|----------------|
| Développeur | _Nom_ | `feature/[nom-feature]` |
| Développeur | _Nom_ | `feature/[nom-feature]` |
| Game Designer | _Nom_ | `gd/[nom-prenom]` |
| Game Designer | _Nom_ | `gd/[nom-prenom]` |
| Artiste | _Nom_ | `art/[nom-prenom]` |
| Artiste | _Nom_ | `art/[nom-prenom]` |

---

## Stack Technique

- **Unity** : `[version, ex: 2022.3.x LTS]`
- **Render Pipeline** : Universal Render Pipeline (URP)
- **Input** : Unity Input System (`InputSystem_Actions`)
- **UI** : TextMesh Pro
- **Versioning** : Git + GitHub (workflow Fork)
- **Gestion de projet** : _[Trello / Notion / Jira]_

---

## Workflow Git

Nous utilisons un **workflow Fork** avec une stratégie de branches structurée.

### Structure des branches

```
main         ← branche stable, builds jouables uniquement
  │
  └── develop    ← branche d'intégration (merges des features)
        │
        ├── feature/[nom-feature]   ← Développeurs (1 branche par feature)
        ├── feature/[nom-feature]
        │
        ├── gd/[prenom]             ← Game Designers (1 branche par GD)
        ├── gd/[prenom]
        │
        ├── art/[prenom]            ← Artistes (1 branche par artiste)
        └── art/[prenom]
```

### Règles importantes

- **Personne ne push directement sur `main`** ni sur `develop`.
- Tout passe par une **Pull Request** depuis votre fork.
- Une PR doit être **review par au moins 1 personne** avant merge.
- Les développeurs créent **1 branche par feature** (jamais une branche perso permanente).
- Les artistes / GD travaillent sur **leur branche personnelle** et la rebase régulièrement sur `develop`.
- **Toujours pull `develop` avant de commencer** quoi que ce soit.

### Setup initial (pour chaque membre)

```bash
# 1. Fork le repo principal sur GitHub (bouton Fork)

# 2. Cloner SON fork
git clone https://github.com/[ton-pseudo]/[nom-repo].git
cd [nom-repo]

# 3. Ajouter le repo principal en "upstream"
git remote add upstream https://github.com/[org-principale]/[nom-repo].git

# 4. Vérifier
git remote -v
# origin    -> ton fork
# upstream  -> repo principal
```

### Workflow quotidien

```bash
# Récupérer les dernières modifs de develop
git checkout develop
git pull upstream develop
git push origin develop

# Créer sa branche de travail
git checkout -b feature/nom-de-la-feature

# ... travailler, commit ...
git add .
git commit -m "feat: ajout du système de tir"

# Push sur son fork
git push origin feature/nom-de-la-feature

# Puis ouvrir une Pull Request sur GitHub vers `develop` du repo principal
```

### Convention de commit

Format : `type: description courte`

| Type | Usage |
|------|-------|
| `feat` | Nouvelle fonctionnalité |
| `fix` | Correction de bug |
| `art` | Ajout / modif d'asset (sprites, audio, vfx) |
| `gd` | Ajout / modif de data, level design, équilibrage |
| `refactor` | Réorganisation de code sans changement de comportement |
| `docs` | Documentation |
| `chore` | Tâches techniques (Unity settings, packages, etc.) |

Exemples :
```
feat: ajout du dash du joueur
fix: collision ennemi qui traverse les murs
art: integration des sprites du boss niveau 1
gd: equilibrage des dégâts du shotgun
```

---

## Architecture du Projet

```
Assets/
│
├── _/                          ← Tout le contenu du jeu (le "_" garde ce dossier en haut)
│   │
│   ├── Content/                ← Assets bruts partagés (artistes)
│   │   ├── Audio/
│   │   ├── GunParts/
│   │   ├── Materials/
│   │   ├── Sprites/
│   │   └── Textures/
│   │
│   ├── DataBase/               ← ScriptableObjects (data du jeu)
│   │   ├── Audio/
│   │   ├── LootTables/
│   │   ├── Prefabs/
│   │   ├── RunData/
│   │   └── Settings/
│   │
│   ├── Features/               ← Code organisé par feature/système
│   │   ├── Audio/
│   │   ├── Common/             ← Code partagé entre features
│   │   ├── Enemy/
│   │   ├── FeatureName/        ← Template pour nouvelle feature
│   │   ├── Gun/
│   │   ├── Health/
│   │   ├── Interactable/
│   │   ├── Items/
│   │   ├── Managers/
│   │   ├── Player/
│   │   ├── Projectile/
│   │   ├── Spawner/
│   │   └── UI/
│   │
│   └── Scenes/
│       ├── 01_MainMenu
│       ├── 02_Game
│       └── 03_EndScreen
│
├── TextMesh Pro/
├── DefaultVolumeProfile
├── InputSystem_Actions
└── UniversalRenderPipelineGlobalSettings
```

### Hiérarchie d'une scène (exemple `02_Game`)

```
02_Game
├── [RENDERERS]       ← Caméras, post-process, lighting
├── [MANAGERS]        ← GameManager, AudioManager, UIManager...
├── [ENVIRONMENT]     ← Décor, tilemaps, props
└── Player            ← Joueur
```

> Les GameObjects entre crochets `[NOM]` sont des conteneurs organisationnels qui apparaissent en haut de la hiérarchie.

### Organisation interne d'une Feature

Chaque dossier dans `Features/` doit suivre cette structure :

```
Features/Player/
├── Scripts/
├── Prefabs/
├── Animations/
└── (Settings ScriptableObjects)
```

---

## Conventions de Nommage

### Code

| Type | Convention | Exemple |
|------|-----------|---------|
| `namespace` | PascalCase | `Game.Player` |
| `class` | PascalCase | `PlayerController` |
| `Method / Function` | PascalCase | `TakeDamage()` |
| Variable `public` | PascalCase | `MaxHealth` |
| Variable `private` | _camelCase | `_currentHealth` |
| Variable `protected` | _camelCase | `_baseSpeed` |
| Variable locale | camelCase | `targetPosition` |
| `Array` (private) | _camelCases | `_enemies` |
| `List` (private) | _camelCaseList | `_enemyList` |
| `Dictionary` (private) | _camelCaseDict | `_lootDict` |
| `Event` | PascalCase | `PlayerDied` |
| Event "during" (en cours) | verbe + `ing` | `OnPlayerMoving` |
| Event "after" (terminé) | verbe + `ed/d` | `OnPlayerDied` |

### Scriptable Objects

| Type | Convention | Exemple |
|------|-----------|---------|
| Script SO (class / menu) | `[Name]SO` | `WeaponSO`, `EnemySO` |
| Asset SO créé | `[Name]Data` | `ShotgunData`, `BossData` |

### Assets

| Type | Préfixe | Exemple |
|------|---------|---------|
| Sprite | `S_` | `S_PlayerIdle` |
| Prefab | `P_` | `P_Enemy_Goblin` |
| SFX | `A_` | `A_GunShot` |
| VFX | `V_` | `V_Explosion` |
| Musique (BGM) | `BGM_` | `BGM_MainMenu` |

---

## 📐 Règles de Code

- **1 classe = 1 fichier**, le fichier porte le nom de la classe.
- Utiliser des **`namespace`** pour chaque feature (ex : `Game.Player`, `Game.Enemy`).
- Préférer **`[SerializeField] private`** plutôt que `public` pour exposer dans l'Inspector.
- **Pas de `Find()` / `FindObjectOfType()`** dans `Update()`.
- Utiliser des **ScriptableObjects** pour toute la data (stats, configs, loot tables).
- Commenter les méthodes publiques avec `/// <summary>`.
- Pas de **magic numbers** : utiliser des constantes ou des champs sérialisés.
- Pas de logique métier dans les `MonoBehaviour` quand c'est évitable (favoriser des classes pures).

---

## Comment Contribuer

1. **Pull** la dernière version de `develop` depuis upstream.
2. **Créer une branche** selon ton rôle :
   - Dev : `feature/[nom-feature]`
   - GD : `gd/[prenom]`
   - Artiste : `art/[prenom]`
3. **Travailler** en respectant les conventions ci-dessus.
4. **Commit** avec des messages clairs (voir convention).
5. **Push** sur ton fork.
6. **Ouvrir une Pull Request** vers `develop` du repo principal.
7. Attendre **au moins 1 review** avant de merger.
8. Une fois mergé, **supprimer la branche** (sauf branches perso GD/Art).

### Avant chaque PR, vérifier que :

- [ ] Le projet compile sans erreur ni warning.
- [ ] Aucune scène n'est cassée.
- [ ] Les conventions de nommage sont respectées.
- [ ] Les nouveaux assets sont dans le bon dossier.
- [ ] Aucun fichier inutile (`.meta` orphelins, backups…) n'est commité.

---

## Notes

- Le fichier `.gitignore` exclut `Library/`, `Temp/`, `Logs/`, `obj/`, `Build/`, etc.
- **Toujours commit les `.meta`** associés aux assets.
- En cas de **conflit sur une scène ou un prefab**, prévenir l'équipe sur le canal commun avant de résoudre.

---

_Dernière mise à jour : [date]_


