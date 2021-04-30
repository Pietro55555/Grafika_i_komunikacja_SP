Program tworzy i wypisuje do plików .txt współrzędne punktów które po naniesieniu na trójwymiarową siatkę 
stworzą czajnik, filiżankę i łyżkę. Program jest napisany w javie i składa się z trzech plików .java,
trzech plików z końcówką _input.txt oraz trzech plików z końcówką _output.txt. W pliku Modele.
java znajduje się main w którym program zczytuję pliki z których wczyta i zapisze koordynaty(x y z) 
punktów oraz wywołanie funkcji wyznacz z klasy nowe_punkty.  Klasa Punkty z pliku Punkty.java zawiera 
w sobie klasę Punkt którego obiekty składają się z trzech zmiennych float które mają reprezentować 
koordynaty. W klasie nowe_punkty znajduje się metoda wyznacz która przyjmuje plik z którego wczytuje 
wartości (Scanner s) oraz plik do którego zapisze wartości (BufferedWriter buf). Funkcja wyznacz przelicza i 
wypisuje do pliku koordynaty nowych punktów korzystając ze wzoru na płat powierzchni beziera 
w którym B_im(v) i B_jn(w) są funkcjami bazowymi Bernsteina o postaci analogicznej jak dla krzywych Beziera. 
Na koniec funkcja wypisuje wartości kordynatów. Dwumian newtona jest liczony przy pomocy funkcji 
Newton która liczy dwumian iteracyjnie. Wyniki obliczeń (koordynaty punktów) są zapisywane do plików z 
końcówką output.
