Program został napisany w c#. Program pozwala na modyfikowania zdjęcia przy pomocy różnych filtrów. Zacznę od pierwszego filtra od góry czyli filtr Robertsa poziomo. Filtr działa w ten sposób że  przy pomocy maski Robertsa są liczone nowe wartości składowych przy pomocy wzoru:
```
            for (int x = 1; x < szerokosc - 1; x++)
            {
                for (int y = 1; y < wysokosc - 1; y++)
                {
                    r = g = b = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                        nowa_składowa += stara_składowa * maska[i,j]
                        }
                    }
                }
            }
  ```
  następnie dla niezerowej zmiennej normowania maski (sumy elementów maski) wartość składowej jest równa wartości ilorazu samej siebie i zmiennej normowania maski. Następnie znajduje się klasyczne (klasyczne względem poprzednich projektów) zabezpieczenie żeby składowa nie wyszła poza przedział [0...255]. Po tym wszystkich ustawiamy nowe składowe jako składowe pixela zdjęcia po filtrowaniu. Pozostałe filtry wyostrzające różnią się jedyne tym że mają inną maske. Reszta algorytmu pozostaje taka sama w każdym.  ![image](https://user-images.githubusercontent.com/80325475/117553605-db6b9600-b052-11eb-9eb4-aaa82797b33b.png)  ``a)operator Robertsa
  b)operator Prewita
  c)operator Sobela
  ``   
 Po filtrach wyostrzających mamy filtry statyczne. W filtrach min i max znajdujemy największą/najmniejszą składową z powierzchni 3x3 i następnie one stają się nowymi składowymi w zdjęciu po filtrowaniu. Filtr mediana ma za zadanie spisać wszystkie wartości składowych z powierzchni 3x3, następnie tablica jest sortowania i wyciągana jest wartość środkowa czyli piąta (z indeksem 4 w tablicy). Wartość środkowa jest nową składową.
  Jako innowacje uznaje możliwośc wyboru trzech podanych masek przy pomocy radio buttonów pod przyciskiem laplacy dla filtra laplacy (gdy trzeba było wybrać jedną)  ![image](https://user-images.githubusercontent.com/80325475/117553583-b6772300-b052-11eb-87ef-0a1a615bc8ba.png)   
 oraz możliość zapisu i przeniesienia zdjęcia z które otrzymaliśmy po filtrowaniu na zdjęcie które filtrujemy.
