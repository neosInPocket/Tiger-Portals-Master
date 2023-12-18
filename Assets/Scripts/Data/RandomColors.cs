using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

[CreateAssetMenu(menuName = "Random Colors", fileName = "RandomColors")]
public class RandomColors : ScriptableObject
{
	[SerializeField] private List<Color> colors;
	public List<Color> Colors => colors;

	public Color GetRandomColor()
	{
		return colors[UnityEngine.Random.Range(0, colors.Count)];
	}

	public List<Color> GetShuffeledList()
	{
		List<Color> shuffeled = colors;

		Random rand = new Random();
		for (int i = 0; i < shuffeled.Count; i++)
		{
			int randomIndex = rand.Next(shuffeled.Count);
			Color temp = shuffeled[i];
			shuffeled[i] = shuffeled[randomIndex];
			shuffeled[randomIndex] = temp;
		}

		return shuffeled;
	}
}
