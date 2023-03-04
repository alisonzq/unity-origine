using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum Character
{ 
    Veilleux,
    Sarah,
    Alison,
}
public class dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public static string[] sentences = { 
        //océanie
        "Bonjour Alison et Sarah, aujourd'hui je serai votre guide touristique de ce voyage virtuel!", //Index 0
        "Wow! Où sommes-nous?", 
        "Nous commençons notre voyage en Océanie.", 
        "C'est magnifique...", 
        "Saviez-vous que la population de l'Océanie en 2021 est de 43 millions!", 
        "Bien que l'Australie n'ait qu'une densité de deux personnes par km2, c’est l'un des pays les plus urbanisés au monde : 91 % de la population vit dans des zones urbaines.",
        "Regardez ce graphique, le taux de fertilité diminue en Australie.",
        "Mais avec l'immigration, sa population demeurera constante à la fin du siècle.", //Index 7
        //Asie
        "La grande muraille de Chine!!", //index 8
        "La population d'Asie est la plus grande aujourd'hui avec 4,6 milliards d'habitants.",
        "Le Japon va perdre presque 20% de sa population d’ici 2050. En effet, plusieurs normes (comme en Chine et en Inde) obligent les familles d’avoir un nombre limité d’enfants, réduisant les taux de natalité.",
        "Malgré cela, d'ici la fin du siècle, la population d'Asie augmentera à plus de 5 milliards.",
        "En route vers l'Europe!",  //12
        //Europe
        "WOW, la tour Eiffel!", //13
        "La population de l'Europe est présentement de 750 millions.", 
        "Certains pays européens, dont le Royaume-Uni, l’Allemagne et l’Italie, comptent sur l’immigration pour accroître leur population à cause des taux de fécondité faibles.",
        "Par exemple, en Allemagne, les femmes ont en moyenne 1,4 enfant.", //16
        //Afrique
        "Les pays de l’Afrique subsaharienne ont les taux de croissance démographique les plus élevés du monde, soit des hausses de 3 % ou 4 % annuellement.", //17
        "Une femme a en moyenne six enfants, ce qui explique l'augmentation exponentielle de la population en Afrique.", 
        "Selon les prévisions, sa population augmentera de 1 à 4 milliards, ce qui contribuera fortement à la surpopulation.", //19
        //Amérique
        "Nous sommes en Amérique!", //20
        "Sa population est de 1 milliard et demeurera constante en 2100.", 
        "Les parents ont en moyenne 2 enfants, ce qui correspond à un bon équilibre. Par contre, comme vous pouvez le voir dans ce graphique, la population mondiale augmentera énormément.", //22
        //Notre vision
        "Voici la fin de notre voyage!", //23
        "Maintenant que vous avez fait le tour du monde, que pensez-vous de l'idée de ne pas avoir d'enfants, ou d'en avoir moins, pour des considérations environnementales?", 
        "Nous pensons qu’il est important de ne pas avoir plus de deux enfants par femme pour permettre à la population mondiale de se stabiliser et de réduire individuellement son empreinte carbone.",
        "L’étude de 2017 dans la revue Environmental Research Letters démontre d’ailleurs qu’avoir un enfant en moins serait la façon la plus efficace de réduire ses émissions de CO2, à raison de 60 tonnes de gaz à effet de serre par an.",
        "Cela pourrait avoir de nombreux effets positifs sur l’environnement en luttant contre les changements climatiques.",
        "Alison, qu'en penses-tu?", //28
        "Si deux enfants peuvent paraître trop peu pour certaines femmes, l’adoption est une autre option qui s’offre à elles.", //39
        "Cependant, nous comprenons que ce sujet est très personnel et que la protection de l’environnement n’est pas une priorité pour certaines.",
        "Les femmes devraient être libres de faire le choix qu’elles veulent sur le nombre d’enfants qu’elles souhaitent avoir, mais en étant éduquées sur les conséquences planétaires qui en découlent pour qu’elles puissent prendre une décision éclairée.",
        "Instaurer des centres d’éducation dans les pays les plus pauvres serait donc un bon moyen pour instruire la population féminine sur ce sujet.",
        "L'éducation dans ces pays permettrait aux filles de découvrir d'autres moyens de contribuer à la société, autrement qu'en ayant des enfants.",
        "Il serait aussi important d’offrir à toutes les femmes, surtout celles les plus démunies, des moyens de protection efficaces pour éviter qu’elles aient un enfant sans le désirer.",
        "Et voilà M. Veilleux! Vous avez été un merveilleux prof tout au long de notre secondaire. Merci beaucoup!!" //36=5

    };
    public static Character[] speaker =
    {
        //océanie
        Character.Veilleux,
        Character.Alison,
        Character.Veilleux,
        Character.Sarah,
        Character.Veilleux,
        Character.Veilleux,
        Character.Veilleux,
        Character.Veilleux,
        //asie
        Character.Sarah,
        Character.Veilleux,
        Character.Veilleux,
        Character.Veilleux,
        Character.Veilleux,
        //europe
        Character.Alison,              
        Character.Veilleux,
        Character.Veilleux,
        Character.Veilleux,
        //Afrique
        Character.Veilleux,
        Character.Veilleux,   
        Character.Veilleux,  
        //Amérique du sud
        Character.Veilleux, 
        Character.Veilleux, 
        Character.Veilleux, 
        //notre vision   
        Character.Veilleux, 
        Character.Veilleux, 
        Character.Sarah, 
        Character.Sarah,    
        Character.Sarah,  
        Character.Sarah,
        Character.Alison,   
        Character.Alison,
        Character.Alison,
        Character.Alison,     
        Character.Alison,    
        Character.Alison, 
        Character.Alison,                                                                                                                                                                              
    };
    int index;
    public int indexStart;
    public int indexEnd;
    public float typingSpeed;
    public GameObject continueButton;

    void Start()
    {
        if(DialogManager.isTalking)
        {
            DialogManager.indexEnd = indexEnd; 
            gameObject.SetActive(false);

        }
        else
        {
            DialogManager.indexEnd = indexEnd; 
            DialogManager.isTalking = true;
            index = indexStart;
            StartCoroutine(Type());
        }
        
    }

    void Update() 
    {
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);     
        }


        // check who's talking
        if(speaker[index] == Character.Veilleux)
        {
            textDisplay.color = new Color(1f, 1f, 1f); 
        }

        if(speaker[index] == Character.Sarah)
        {
            textDisplay.color = new Color(1f, 0.83f, 1f);
            
        }

        if(speaker[index] == Character.Alison)
        {
            textDisplay.color = new Color(0.6f, 1.0f, 1.0f); 
        }



    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {

        continueButton.SetActive(false);
        

        if(index < DialogManager.indexEnd)
        {
            index++;
            textDisplay.text = ""; 
            StartCoroutine(Type());
        } 
        else
        {
            DialogManager.isTalking = false;
            textDisplay.text = "";

            continueButton.SetActive(false);
            
        }
    }



}
