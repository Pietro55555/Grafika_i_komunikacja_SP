Jest to aplikacja okienkowa która transoformuje liniowo i potęgowo wybrane zdjęcie oraz miesza dwa zdjęcia ze sobą. Środkowa i dolna część aplikacji skłąda się z trzech okienek na zdjęcia z czego duże okno na prawo pokazuje wyniki naszych transformacji a dwa mniejsze okna na lewo dwa pokazują wczytane zdjęcia przy pomocy przycisków:
```
Wczytaj 1 - wczytuje zdjęcie główne na którym można przeprowadzać tansformacje (górne mniejsze okienko)
Wczytaj 2 - wczytuje zdjęcie z którym mieszamy zdjęciem główne przy użyciu któregoś z trybów mieszania (dolne mniejsze okienko)
```
Idąc na prawo od przycisków wczytania, znajdują się dwie kratki w których możemy wpisać wartość o jaką chcemy zmienić jasność (Jeśli wartośc jest <0 to przyciemniamy a jak >0 to rozjaśniamy) oraz znajduje się tam kratka służąca do zmiany wartości współczynnika. Pod miejscami do wpisana wartośći mamy przyciski do zmiany jasność i negatywu (negatyw jest tylko w liniowej)
1. Transformacja Liniowa
   - Zmiana jasności dodaje wartość podaną w okienku "Jaśniej/Ciemnije o:"
   - Negatyw tworzy z aktualnego zdjęcia negatyw odejmując od 255 wartość R,G i B pixela 
2. Transformacja Potęgowa
   - Zmiana jasnosci zmienia wartośc R,G i B pixela na wartosc składowej podniesionej do potęgi o wartosci podanej jako wartosc jasniej/ciemniej oraz jest przemnożona przez współczynnik

**Do wszystkich wyżej wymienionych Transformacji wykorzystuje zabezpieczenia w postaci dwóch ifów które:**
 ```
 if(wynik_wzoru <0) 
   wtedy nowa_wartosc_składowej jest równa 0
 else if(wynik_wzoru >255)
   wtedy nowa_wartosc_składowej jest równa 255
 else
 w przeciwnym razie policz nowa_wartosc_składowej ze wzoru
 ```
Następnie na prawo od wyżej wymienianych elementów znajdują się przyciski do mieszania zdjęć. Zdjęcia można mieszać gdy jest wczytane zdjęcie główne i zdjęcie z którym mieszamy.
Efekty so uzyskiwane przy użyciu wzorów z [pdf do lab5](https://blackboard.uwb.edu.pl/bbcswebdav/pid-89131-dt-content-rid-562341_1/courses/A2020-420-IS1-2GRA-LAB3/lab_5.pdf). W przypadku mieszania w kodzie są trzy rodzaje zabezpieczeń zależne od wzoru mieszania:
W przypadku wzorów bez dzielenia i bez if-ów np.
![](https://github.com/Pietro55555/Grafika_i_komunikacja_SP/blob/main/transformacje/README_ss/mieszanie1.PNG)    
stosujemy zabezpieczenia takie jak do transformacji:
 ```
 if(wynik_wzoru <0) 
   nowa_składowej = 0
 else if(wynik_wzoru >255)
   nowa_składowej = 255
 else
 policz nowa_składowej ze wzoru
 ```
 przy wzorach z if-ami i bez dzielenia takich jak
 ![](https://user-images.githubusercontent.com/80325475/116687930-3c8dcc80-a9b6-11eb-9915-336f0b073c20.png)  
 stosujemy zabezpiecznie:
 ```
 if(składowa > 127) //0.5 = 127 = 255/2
 {
  if(wynik_wzoru_ifa <0) 
   nowa_składowej = 0
 else if(wynik_wzoru_ifa >255)
   nowa_składowej = 255
 else
 policz nowa_składowej ze wzoru przy if-ie
 }
 else
 {
   if(wynik_wzoru_elsa <0) 
   nowa_składowej = 0
 else if(wynik_wzoru_elsa >255)
   nowa_składowej = 255
 else
 policz nowa_składowej ze wzoru przy elsie
 }
 ```
