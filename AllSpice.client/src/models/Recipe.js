function convertInstructionsToSteps(instructions) {
  const steps = instructions.split(" + ");
  return steps;
}

export class Recipe {
  constructor(data) {
    this.id = data.id
    this.title = data.title
    this.instructions = data.instructions
    this.img = data.img
    this.category = data.category
    this.creatorId = data.creatorId
    this.creator = data.creator
    this.description = data.description
    this.steps = convertInstructionsToSteps(data.instructions)

  }
}
