import { GraveOwnerDTO } from "./graveowner.model";

export class RegistrarDTO {
  id: number;
  bookPage: string;
  numberInBook: number;
  firstName: string;
  lastName: string;
  sex: string;
  age: number;
  ageDetail: string;
  religion: string;
  occupation: string;
  deathLocation: string;
  marriageStatus: string;
  deathDate: Date;
  burialDate: Date;
  public: string;
  proprietary: string;
  sectionInfo: string;
  numberInfo: string;
  internmentSignatur: string;
  additionalComments: string;
  registrarName: string;
  graveOwner: GraveOwnerDTO;
}
