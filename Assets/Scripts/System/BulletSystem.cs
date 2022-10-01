using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSystem : MonoBehaviour
{
    public LevelComponent level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var bulletTime = 0.5f;
        var bulletFlyTime = 0.15f;

        var i = level.bullets.Count;
        while(i > 0)
        {
            i--;
            var bullet = level.bullets[i];
            bullet.time += Time.deltaTime;
            if (bullet.time < bulletTime)
            {
                var target = Vector3.Lerp(bullet.start, bullet.target ? bullet.target.position : bullet.lastTargetPosition + bullet.targetOffset , bullet.time / bulletFlyTime);
                //var target = bullet.target.position + bullet.targetOffset;
                Vector3[] positions = { bullet.line.transform.InverseTransformPoint(bullet.start), bullet.line.transform.InverseTransformPoint(target) };
                bullet.line.SetPositions(positions);

                var endColor = bullet.color;
                endColor.a = 0f;
                Color color = Vector4.Lerp(bullet.color, endColor, bullet.time / bulletFlyTime - bulletFlyTime * 2);
                bullet.line.startColor = bullet.line.endColor = color;

                if (bullet.target)
                {
                    bullet.lastTargetPosition = bullet.target.position;
                }
            }
            else
            {
                level.bullets.Remove(bullet);
                Destroy(bullet.gameObject);
            }
        }
    }
}
