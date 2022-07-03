##BubbleTroubleGame
Проект по предметот Визуелно Програмирање за 2021/22 година, изработен од: Александар Радуловски 201518, Деспина Мишева 201531 и Кристијан Стамески 201556

##1. Опис на апликацијата
Апликацијата е имитација на играта Bubble Trouble, со сите нејзини функционалности и дополнително проширена со Level Editor опција. Искористивме сопствени цртежи за аватарите на играчите и севкупниот изглед на апликацијата, но при тоа концентрирајќи се на функционалностите кои би биле од корист на корисникот на апликацијата. 

##2. Упатство за користење
##2.1. Main menu
Во главното мени кое се појавува на почеток на апликацијата на корисникот се нудат опции да игра сам (копчиња A, D и W) или двајца играчи (стрелки за лево, десно и горе - за вториот играч, во сина боја). Дополнително се нуди опција за вчитување на веќе зачувано ниво или користење на Level Еditor-от.
##2.2. Game window + Game rules
По избирање на бројот на играчи се вчитува нивото на играта и секој играч започнува со по 5 животи. Со погодок на топче тоа се разделува на две, двојно помали топчиња кои се движат во спротивни правци. Целта на играта е да се испукаат (исчистат,уништат) сите топчиња. Играчите губат живот доколку дојдат во контакт со топче. Доколку еден од двата играчи ги загуби сите 5 животи, станува плоча и може да продолжи да се движи но не и да го користи харпунот за погодување на топчиња. Има и опција за паузирање на играта со Esc копчето на тастатура, по што се отвара панел со опции. По успешно (или неуспешно) завршување на нивото се појавува друг панел со соодветна порака и опција за враќање кон почетното мени. За крај на ниво се смета доколку сите играчи ги изгубат своите животи или не останат повеќе топчиња.
##2.3. Level editor
Во овој дел се овозможува креирање на custom нивоа за играње со додавање на топчиња со лев клик и нивно селектирање и менување радиус со понудената контрола на дното на прозорецот. PlayTest опцијата овозможува играње на креираното custom ниво.
##2.4. Level Load
Се вчитува мени со веќе готови нивоа од кои со клик се избира посакуваното ниво за играње.

##3. Опис на имплементацијата
Сите класи (поточно Player, Ball, Harpoon и Obstacle) го користат Drawable интерфејсот. Сликите за играчот и срцињата кои ги симболизираат преостанатите животи се креирани со pixilart.com, бесплатно. Движењето на топчињата е симулирано со физички формули, додека пак на играчот е обична транслација по Х-оската, без вертикални промени во позицијата. Објектите се комбинирани во класа Scene која всушност претставува посебно ниво и служи како мост меѓу формата (која ги прима инпутите на корисникот) и соодветните класи.

##4. Опис на функцијата Scene/tick()
Како една од најбитните но и најкомплексни функции, оваа функција се извршува на секое отчукување на тајмерот и е одговорна за придвижување на топчињата, и проверува дали се во контакт со објекти од класите Harpoon или Player. Доколку топче е погодено од Harpoon, тоа се брише и на негово место се додаваат две нови топчиња кои се движат во спротивни правци. Доколку пак, топче дојде во контакт со објект од класата Player, соодветниот играч губи живот. За да не се изгубат сите животи при еден удар на топчето (бидејќи топчињата не се оддалечуваат од играчот во еден timer tick), се имплементираат и flag-ови во оваа функција кои се менуваат на првиот tick кога играчот стапува во (односно губи) контакт со некое од топчињата. При истрел на Harpoon, тој инкрементално се зголемува кон врвот на формата. Играч без животи не смее да користи Harpoon, туку само да се движи со својата плоча во знак на поддршка за другиот играч.
