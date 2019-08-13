import { DescriptionModel } from './description.model';
import { EducationModel } from './education.model';
import { ExperienceModel } from './experience.model';

export class EmployeeDetailsModel {
    id: string;
    email: string;
    userName: string;
    firstName: string;
    lastName: string;
    photo?: Blob;
    birthDate?: Date;
    city: string;
    country: string;
    phoneNumber: string;
    skype: string;
    description?: DescriptionModel;
    skills?: string[];
    educations?: EducationModel[];
    languages?: string[];
    experiences?: ExperienceModel[];
}