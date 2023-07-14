using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UniRx;
using UniRx.Triggers;
using TMPro;

namespace Minefarm.Entity
{
    public class EntityModel : MonoBehaviour
    {
        public UnityEvent onSpawn = new UnityEvent();
        public UnityEvent onDeath = new UnityEvent();

        /// <summary>
        /// ��ƼƼ ����
        /// </summary>
        public EntityID entityID;
        /// <summary>
        /// ��ƼƼ �Ҽ�
        /// </summary>
        public EntityGroup group;
        
        /// <summary>
        /// ���� ����
        /// </summary>
        public bool isLive;

        /// <summary>
        /// �ִ� ü��
        /// </summary>
        public int maxHp;
        public float maxHpPercent = 1.0f;
        /// <summary>
        /// ü��
        /// </summary>
        public int hp;

        public int GetMaxHp() => Mathf.RoundToInt(maxHpPercent * maxHp);
    }
}