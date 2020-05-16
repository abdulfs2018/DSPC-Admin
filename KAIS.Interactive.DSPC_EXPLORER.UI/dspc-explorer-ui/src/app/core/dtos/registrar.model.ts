import { GraveOwnerDTO } from "./graveowner.model";

export class RegistrarDTO {
  Id: number;
  BookPage: string;
  NumberInBook: number;
  FirstName: string;
  LastName: string;
  Sex: string;
  Age: number;
  AgeDetail: string;
  Religion: string;
  Occupation: string;
  DeathLocation: string;
  MarriageStatus: string;
  DeathDate: Date;
  BurialDate: Date;
  Public: string;
  Proprietary: string;
  SectionInfo: string;
  NumberInfo: string;
  InternmentSignatur: string;
  AdditionalComments: string;
  RegistrarName: string;
  GraveOwner: GraveOwnerDTO;
}
