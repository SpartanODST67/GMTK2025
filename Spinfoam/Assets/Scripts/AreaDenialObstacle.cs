using System.Collections;
using UnityEngine;

public class AreaDenialObstacle : Obstacle
{
    [SerializeField] float height = 10f;
    [SerializeField] Vector2 widthRange;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Vector3 inactiveTransparency;
    [SerializeField] float timeBetweenFlashes = .5f;
    [SerializeField] int numFlashes = 10;

    public override void Spawn()
    {
        hitBox.enabled = false;
        Color temp = sprite.color;
        temp.a = inactiveTransparency.x;
        sprite.color = temp;
        transform.position = new Vector2(transform.position.x, 0);

        float width = Random.Range(widthRange.x, widthRange.y);
        transform.localScale = new Vector2(width, height);

        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        for (int flash = 0; flash < numFlashes; flash++)
        {
            Color temp = sprite.color;
            temp.a = flash % 2 == 0 ? inactiveTransparency.x : inactiveTransparency.y;
            sprite.color = temp;
            Debug.Log(sprite.color);
            yield return new WaitForSeconds(timeBetweenFlashes);
        }
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, inactiveTransparency.z);

        yield return new WaitForSeconds(timeBetweenFlashes);

        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
        sprite.enabled = true;
        hitBox.enabled = true;

        Invoke(nameof(Despawn), timeBetweenFlashes);
    }

    public override void Despawn()
    {
        base.Despawn();
        Destroy(gameObject);
    }
}
