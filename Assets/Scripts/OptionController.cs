﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.IO;

public class OptionController: MonoBehaviour
{
	
	public Text textoPuntos;
	

    public  Button button1;
	public  Button button2;
	public Button button3;

	public Text nombre1;
	public Text nombre2;
	public Text nombre3;


	private List<string> animales;
    private int  puntos;
	private string nombreCorrecto = "";


	#region UNITY_MONOBEHAVIOUR_METHODS


	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}


	void Start()
    {
		
		animales = new List<string>();
		//ActualizaPuntos();
		//InicializarNombres();
	}

	#endregion

	#region PRIVATE_METHODS
	public void SumarPuntos() {
		puntos++;
		ActualizaPuntos();
    }

	private void ActualizaPuntos() {
	 textoPuntos.text = textoPuntos +" "+ puntos;
    }


	public string GetNombreAnimal()
	{
		return this.nombreCorrecto;
	}


	private IEnumerator AddNombre(string nombreAnimal) {




		yield return new WaitForSeconds(0.2f);

		//Inicializo una lista de animales auxiliar para trabajar con ella
		nombreCorrecto = nombreAnimal;
	

		if (animales.Contains(nombreAnimal)) animales.Remove(nombreAnimal);

		//Buscamos 3 posiciones aleatorias al tener ya en nombre del target
		int x = Random.Range(0, 9);
		int y = Random.Range(0, 9);
		int z = Random.Range(0, 9);


		int pos = Random.Range(1, 4);

		switch (pos)
		{
			case 1:
				nombre1.text = "" + nombreAnimal;
				int noRepetidaY = (y == z) ? Random.Range(0, y) : y;
				nombre2.text = "" + animales[noRepetidaY];
				nombre3.text = "" + animales[z];
				break;
			case 2:
				int noRepetidaZ = (x == z) ? Random.Range(0, z) : z;
				nombre1.text = "" + animales[x];
				nombre2.text = "" + nombreAnimal;
				nombre3.text = "" + animales[noRepetidaZ];
				break;

			case 3:
				int noRepetidaX = (x == y) ? Random.Range(0, x) : x;
				nombre1.text = "" + animales[noRepetidaX];
				nombre2.text = "" + animales[y];
				nombre3.text = "" + nombreAnimal;
				break;


		}
		animales.Clear();

	
	}


	private void InicializarNombres() {

		    animales.Add("Panda");
			animales.Add("Fox");
			animales.Add("Sheep");
			animales.Add("Elephant");
			animales.Add("Chiken");
			animales.Add("Monkey");
			animales.Add("Tiger");
			animales.Add("Duckling");
			animales.Add("Lizard");
			animales.Add("Penguin");


		//yield return new WaitForSeconds(0.1f);


	}
	#endregion









	#region PUBLIC_ METHOD
	public void ActivarBotones(string nombreAnimal) {
		InicializarNombres();
		StartCoroutine(AddNombre(nombreAnimal));

		if (!button1.gameObject.activeInHierarchy)
		{
			button1.gameObject.SetActive(true);
		}
		else if (!button2.gameObject.activeInHierarchy)
		{
			button2.gameObject.SetActive(true);
		}
		else if (!button3.gameObject.activeInHierarchy)
		{
			button3.gameObject.SetActive(true);
		}


		}




		#endregion

	}
