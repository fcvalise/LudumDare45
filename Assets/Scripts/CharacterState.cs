using UnityEngine;

public class CharacterState : MonoBehaviour
{
	public LayerMask _waterLayerMask;
	public bool _isInWater = false;
	
	private void Update() {
		_isInWater = Physics2D.OverlapCircle(transform.position, 0.1f, _waterLayerMask);
	}
}
