﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using EGamePlay;
using EGamePlay.Combat;
using EGamePlay.Combat.Skill;

namespace EGamePlay.Combat.Skill
{
    /// <summary>
    /// 技能施法组件
    /// </summary>
    public class SpellComponent : EGamePlay.Component
    {
        private CombatEntity CombatEntity => GetEntity<CombatEntity>();
        public override bool Enable { get; set; } = true;


        public override void Setup()
        {

        }

        public void SpellWithTarget(SkillAbility SpellSkill, CombatEntity targetEntity)
        {
            if (CombatEntity.CurrentSkillExecution != null)
                return;

            //Log.Debug($"OnInputTarget {combatEntity}");
            if (CombatEntity.SpellActionAbility.TryCreateAction(out var action))
            {
                action.SkillAbility = SpellSkill;
                action.SkillExecution = SpellSkill.CreateExecution() as SkillExecution;
                action.SkillTargets.Add(targetEntity);
                action.SkillExecution.InputTarget = targetEntity;
                action.SpellSkill();
            }
        }

        public void SpellWithPoint(SkillAbility SpellSkill, Vector3 point)
        {
            if (CombatEntity.CurrentSkillExecution != null)
                return;

            //Log.Debug($"OnInputPoint {point}");
            if (CombatEntity.SpellActionAbility.TryCreateAction(out var action))
            {
                action.SkillAbility = SpellSkill;
                action.SkillExecution = SpellSkill.CreateExecution() as SkillExecution;
                action.SkillExecution.InputPoint = point;
                action.SpellSkill();
            }
        }

        public void SpellWithDirect(SkillAbility SpellSkill, float direction, Vector3 point)
        {
            if (CombatEntity.CurrentSkillExecution != null)
                return;

            //Log.Debug($"OnInputDirect {direction}");
            if (CombatEntity.SpellActionAbility.TryCreateAction(out var action))
            {
                action.SkillAbility = SpellSkill;
                action.SkillExecution = SpellSkill.CreateExecution() as SkillExecution;
                action.SkillExecution.InputPoint = point;
                action.SkillExecution.InputDirection = direction;
                action.SpellSkill();
            }
        }
    }
}