import { Skill } from "../../shared/models/skill.model";

export class Advertisement {
    id: number;
    title: string;
    description: string;
    url: string;
    skills: Skill[];
    applied: boolean
    applyDate: Date
    rejected: boolean

    constructor(
        id: number,
        title: string,
        description: string,
        url: string,
        skills: Skill[],
        applied: boolean,
        applyDate: Date,
        rejected: boolean) {
        this.id = id;
        this.title = title;
        this.description = description;
        this.url = url;
        this.skills = skills;
        this.applied = applied;
        this.applyDate = applyDate;
        this.rejected = rejected;
    }
}