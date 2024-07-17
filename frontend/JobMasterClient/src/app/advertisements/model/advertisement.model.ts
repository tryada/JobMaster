export class Advertisement {
    id: string;
    title: string;
    companyName: string;
    description: string;
    url: string;
    skills: string[];
    applied: boolean
    appliedDate: Date
    rejected: boolean
    replied: boolean
    replyDate: Date

    constructor(
        id: string,
        title: string,
        companyName: string,
        description: string,
        url: string,
        skills: string[],
        applied: boolean,
        applyDate: Date,
        rejected: boolean,
        replied: boolean,
        replyDate: Date) {
        this.id = id;
        this.title = title;
        this.companyName = companyName;
        this.description = description;
        this.url = url;
        this.skills = skills;
        this.applied = applied;
        this.appliedDate = applyDate;
        this.rejected = rejected;
        this.replied = replied;
        this.replyDate = replyDate;
    }
}