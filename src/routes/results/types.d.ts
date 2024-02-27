export type ModelResponse = {
	guess0: { 
		species: string,
		bone: string,
		score: number,
	},
	guess1: { 
		species: string,
		bone: string,
		score: number,
	},
	guess2: { 
		species: string,
		bone: string,
		score: number,
	},
	session: string,
}

export type ChatResponse = {
	summary: string,
	followup0: string,
	followup1: string,
	followup2: string,
	answer: string
}