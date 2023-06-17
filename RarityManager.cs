using UnityEngine;

public class RarityManager : MonoBehaviour
{
    public static int[] rarityValues = new int[] { 0, 3, 4, 2};    //The index number can be treated as the token number.
                                                                                        // When introducing a new token, just create a new position in the array with
                                                                                        // the rarity of that element.

    private void Start()
    {
        Debug.Log("\n1 = Common \n2 = Less Rare \n3 = Epic \n4 = Legendary");
    }
}
