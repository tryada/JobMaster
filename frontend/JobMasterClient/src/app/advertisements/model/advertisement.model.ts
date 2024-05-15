import { Skill } from "../../shared/models/skill.model";

export class Advertisement {
    id: number;
    title: string;
    companyName: string;
    description: string;
    url: string;
    skills: Skill[];
    applied: boolean
    appliedDate: Date
    rejected: boolean

    constructor(
        id: number,
        title: string,
        companyName: string,
        description: string,
        url: string,
        skills: Skill[],
        applied: boolean,
        applyDate: Date,
        rejected: boolean) {
        this.id = id;
        this.title = title;
        this.companyName = companyName;
        this.description = description;
        this.url = url;
        this.skills = skills;
        this.applied = applied;
        this.appliedDate = applyDate;
        this.rejected = rejected;
    }
}