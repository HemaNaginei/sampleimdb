# sampleimdb
here I am using EntityFramework CodeFirstApproach ,created three tables named Actor,Producer,Movies and here used many to many relationship between these three tables.for building mamy to many relationship I created Sample model class .These three Primary Keys are defined as foriegn key in the table.
for inserting the data in these tables  (Actor,Producer,Movies,Sample) created api named InsertActor,InsertProducer,InsertSample,InsertMovies.
for Updating the the tables created api named UpadteActor,UpdateProducer,UpdateMovies,UpdateSample.
for deleteing the tables created api named DeleteActor,DeleteProducer,DeleteSample,DeleteMovies.for getting the All details of the table created api named api GetAllProducer,GetAllActor,GetAllMovies,GetAllSample.for getting the details by Id created GetActorById,GetProducerById,GetMoviesById,GetSampleById.
for getting the Dropdown list of Actor and Producer created api named GetAllActorDD,GetAllProducerDD(when inserting the Movies the dropdown list will added)
(I did not used any storedProcedure)
