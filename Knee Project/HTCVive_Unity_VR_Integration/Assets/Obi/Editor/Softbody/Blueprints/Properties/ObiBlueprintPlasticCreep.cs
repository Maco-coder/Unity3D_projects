﻿namespace Obi
{
    public class ObiBlueprintPlasticCreep : ObiBlueprintFloatProperty
    {

        public ObiBlueprintPlasticCreep(ObiActorBlueprintEditor editor) : base(editor, 0)
        {
            brushModes.Add(new ObiFloatPaintBrushMode(this));
            brushModes.Add(new ObiFloatAddBrushMode(this));
            brushModes.Add(new ObiFloatCopyBrushMode(this, this));
            brushModes.Add(new ObiFloatSmoothBrushMode(this));
        }

        public override string name
        {
            get { return "Plastic creep"; }
        }

        public override float Get(int index)
        {
            var constraints = editor.blueprint.GetConstraintsByType(Oni.ConstraintType.ShapeMatching) as ObiConstraints<ObiShapeMatchingConstraintsBatch>;
            foreach (var batch in constraints.batches)
            {
                for (int i = batch.constraintCount - 1; i >= 0; --i)
                {
                    int firstParticle = batch.particleIndices[batch.firstIndex[i]];
                    if (firstParticle == index)
                    {
                        return batch.materialParameters[i * 5 + 2];
                    }
                }
            }
            return 0;
        }
        public override void Set(int index, float value)
        {
            var constraints = editor.blueprint.GetConstraintsByType(Oni.ConstraintType.ShapeMatching) as ObiConstraints<ObiShapeMatchingConstraintsBatch>;
            foreach (var batch in constraints.batches)
            {
                for (int i = batch.constraintCount - 1; i >= 0; --i)
                {
                    int firstParticle = batch.particleIndices[batch.firstIndex[i]];
                    if (firstParticle == index)
                    {
                        batch.materialParameters[i * 5 + 2] = value;
                        editor.blueprint.edited = true;
                        return;
                    }
                }
            }
        }
        public override bool Masked(int index)
        {
            return !editor.Editable(index);
        }
    }
}
