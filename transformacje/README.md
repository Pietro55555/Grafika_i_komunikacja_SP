Jest to aplikacja okienkowa która transoformuje liniowo i potęgowo wybrane zdjęcie oraz miesza dwa zdjęcia ze sobą. Środkowa i dolna część aplikacji skłąda się z trzech okienek na zdjęcia z czego dwa zdjęcia (dwa mniejsze okna na lewo) należy wczytać używając przycisków:
```
Wczytaj 1 - wczytuje zdjęcie główne na którym można przeprowadzać tansformacje (górne mniejsze okienko)
Wczytaj 2 - wczytuje zdjęcie do mieszania które jest wykorzystywane do mieszania się z zdjęciem głównym 
            przy użyciu któregoś z trybów mieszania
```
Idąc na prawo od przycisków wczytania, znajdują się dwie kratki w których możemy wpisać wartość o jaką chcemy zmienić jasność (Jeśli wartośc jest <0 to przyciemniamy a jak >0 to rozjaśniamy) oraz znajduje się tam kratka służąca do zmiany wartości współczynnika. Pod miejscami do wpisana wartośći mamy przyciski do zmiany jasność i negatywu (negatyw jest tylko w liniowej)
1. Transformacja Liniowa
   - Zmiana jasności dodaje wartość podaną w okienku "Jaśniej/Ciemnije o:"
   - Negatyw tworzy z aktualnego zdjęcia negatyw odejmując od 255 wartość R,G i B pixela 
2. Transformacja Potęgowa
   - Zmiana jasnosci zmienia wartośc R,G i B pixela na wartosc składowej podniesionej do potęgi o wartosci podanej jako wartosc jasniej/ciemniej oraz jest przemnożona przez współczynnik

**Do wszystkich wyżej wymienionych Transformacji wykorzystuje zabezpieczenia w postaci dwóch ifów które:**
 ```
 if(nowa_wartosc_składowej <0) 
   wtedy nowa_wartosc_składowej jest równa 0
 else if(nowa_wartosc_składowej >255)
   wtedy nowa_wartosc_składowej jest równa 255
 else
 w przeciwnym razie policz nowa_wartosc_składowej ze wzoru
 ```
